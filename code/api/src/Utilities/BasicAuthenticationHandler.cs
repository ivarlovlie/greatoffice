using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Options;

namespace IOL.GreatOffice.Api.Utilities;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
	private readonly MainAppDatabase _context;
	private readonly AppConfiguration _configuration;
	private readonly ILogger<BasicAuthenticationHandler> _logger;

	public BasicAuthenticationHandler(
			IOptionsMonitor<AuthenticationSchemeOptions> options,
			ILoggerFactory logger,
			UrlEncoder encoder,
			ISystemClock clock,
			MainAppDatabase context,
			VaultService vaultService
	) :
			base(options, logger, encoder, clock) {
		_context = context;
		_configuration = vaultService.GetCurrentAppConfiguration();
		_logger = logger.CreateLogger<BasicAuthenticationHandler>();
	}

	protected override Task<AuthenticateResult> HandleAuthenticateAsync() {
		var endpoint = Context.GetEndpoint();
		if (endpoint?.Metadata.GetMetadata<IAllowAnonymous>() != null)
			return Task.FromResult(AuthenticateResult.NoResult());

		if (!Request.Headers.ContainsKey("Authorization"))
			return Task.FromResult(AuthenticateResult.Fail("Missing Authorization Header"));

		try {
			var tokenEntropy = _configuration.APP_AES_KEY;
			if (tokenEntropy.IsNullOrWhiteSpace()) {
				_logger.LogWarning("No token entropy is available in env:TOKEN_ENTROPY, Basic auth is disabled");
				return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
			}

			var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
			if (authHeader.Parameter == null) return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
			var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
			var decryptedString = Encoding.UTF8.GetString(credentialBytes).DecryptWithAes(tokenEntropy);
			var tokenIsGuid = Guid.TryParse(decryptedString, out var tokenId);

			if (!tokenIsGuid) {
				return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
			}

			var token = _context.AccessTokens.Include(c => c.User).SingleOrDefault(c => c.Id == tokenId);
			if (token == default) {
				return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header: Not Found"));
			}

			if (token.HasExpired) {
				return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header: Expired"));
			}

			var permissions = new List<Claim>() {
					new(AppConstants.TOKEN_ALLOW_READ, token.AllowRead.ToString()),
					new(AppConstants.TOKEN_ALLOW_UPDATE, token.AllowUpdate.ToString()),
					new(AppConstants.TOKEN_ALLOW_CREATE, token.AllowCreate.ToString()),
					new(AppConstants.TOKEN_ALLOW_DELETE, token.AllowDelete.ToString()),
			};
			var claims = token.User.DefaultClaims().Concat(permissions);
			var identity = new ClaimsIdentity(claims, AppConstants.BASIC_AUTH_SCHEME);
			var principal = new ClaimsPrincipal(identity);
			var ticket = new AuthenticationTicket(principal, AppConstants.BASIC_AUTH_SCHEME);

			return Task.FromResult(AuthenticateResult.Success(ticket));
		} catch (Exception e) {
			_logger.LogError(e, $"An exception occured when challenging {AppConstants.BASIC_AUTH_SCHEME}");
			return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
		}
	}
}
