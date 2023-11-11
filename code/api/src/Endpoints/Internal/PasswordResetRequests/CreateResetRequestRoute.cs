namespace IOL.GreatOffice.Api.Endpoints.Internal.PasswordResetRequests;

public class CreateResetRequestRoute : RouteBaseAsync.WithRequest<CreateResetRequestRoute.Payload>.WithActionResult
{
    private readonly ILogger<CreateResetRequestRoute> _logger;
    private readonly PasswordResetService _passwordResetService;
    private readonly MainAppDatabase _database;
    private readonly IStringLocalizer<SharedResources> _localizer;

    public CreateResetRequestRoute(ILogger<CreateResetRequestRoute> logger, PasswordResetService passwordResetService, MainAppDatabase database, IStringLocalizer<SharedResources> localizer) {
        _logger = logger;
        _passwordResetService = passwordResetService;
        _database = database;
        _localizer = localizer;
    }

    public class Payload
    {
        public string Email { get; set; }
    }

    [AllowAnonymous]
    [HttpPost("~/_/password-reset-request/create")]
    public override async Task<ActionResult> HandleAsync(Payload payload, CancellationToken cancellationToken = default) {
        if (payload.Email.IsNullOrWhiteSpace()) {
            return KnownProblem(_localizer["Invalid form"],
                _localizer["One or more fields is invalid"],
                new() {{"email", new string[] {_localizer["Email is a required field"]}}}
            );
        }

        var tz = GetRequestTimeZone(_logger);
        _logger.LogInformation("Creating forgot password request with local date time: " + tz.LocalDateTime.ToString("u"));
        var user = _database.Users.FirstOrDefault(c => c.Username.Equals(payload.Email));
        // Don't inform the caller that the user does not exist.
        if (user == default) return Ok();
        await _passwordResetService.AddRequestAsync(user, tz.TimeZoneInfo, cancellationToken);
        return Ok();
    }
}