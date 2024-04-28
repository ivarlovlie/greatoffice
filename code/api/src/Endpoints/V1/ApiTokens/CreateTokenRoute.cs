using System.Text;

namespace IOL.GreatOffice.Api.Endpoints.V1.ApiTokens;

public class CreateTokenRoute : RouteBaseSync.WithRequest<CreateTokenRoute.Payload>.WithActionResult
{
    private readonly MainAppDatabase _database;
    private readonly ILogger<CreateTokenRoute> _logger;

    public CreateTokenRoute(MainAppDatabase database, ILogger<CreateTokenRoute> logger)
    {
        _database = database;
        _logger = logger;
    }

    public class Payload
    {
        public DateTime ExpiryDate { get; set; }
        public bool AllowRead { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }
    }

    /// <summary>
    /// Create a new api token with the provided claims.
    /// </summary>
    /// <param name="request">The claims to set on the api token</param>
    /// <returns></returns>
    [ApiVersion(ApiSpecV1.VERSION_STRING)]
    [HttpPost("~/v{version:apiVersion}/api-tokens/create")]
    public override ActionResult Handle(Payload request)
    {
        var user = _database.Users.FirstOrDefault(c => c.Id == LoggedInUser.Id);
        if (user == default)
        {
            return NotFound(new KnownProblemModel("User does not exist"));
        }

        var tokenEntropy = Program.AppConfiguration.APP_AES_KEY;
        if (tokenEntropy.IsNullOrWhiteSpace())
        {
            _logger.LogWarning("No token entropy is available, Basic auth is disabled");
            return NotFound();
        }

        var accessToken = new ApiAccessToken()
        {
            User = user,
            ExpiryDate = request.ExpiryDate.ToUniversalTime(),
            AllowCreate = request.AllowCreate,
            AllowRead = request.AllowRead,
            AllowDelete = request.AllowDelete,
            AllowUpdate = request.AllowUpdate
        };

        _database.AccessTokens.Add(accessToken);
        _database.SaveChanges();
        return Ok(Convert.ToBase64String(Encoding.UTF8.GetBytes(accessToken.Id.ToString().EncryptWithAes(tokenEntropy))));
    }
}
