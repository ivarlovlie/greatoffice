namespace IOL.GreatOffice.Api.Endpoints.V1.ApiTokens;

public class GetTokensRoute : RouteBaseSync.WithoutRequest.WithResult<ActionResult<List<GetTokensRoute.ResponseModel>>>
{
    private readonly MainAppDatabase _database;

    public GetTokensRoute(MainAppDatabase database) {
        _database = database;
    }

    public class ResponseModel
    {
        public DateTime ExpiryDate { get; set; }
        public bool AllowRead { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }
        public bool HasExpired => ExpiryDate < AppDateTime.UtcNow;
    }

    /// <summary>
    /// Get all tokens, both active and inactive.
    /// </summary>
    /// <returns>A list of tokens</returns>
    [ApiVersion(ApiSpecV1.VERSION_STRING)]
    [HttpGet("~/v{version:apiVersion}/api-tokens")]
    public override ActionResult<List<ResponseModel>> Handle() {
        return Ok(_database.AccessTokens.Where(c => c.User.Id == LoggedInUser.Id).Select(c => new ResponseModel() {
            AllowCreate = c.AllowCreate,
            AllowRead = c.AllowRead,
            AllowDelete = c.AllowDelete,
            AllowUpdate = c.AllowUpdate,
            ExpiryDate = c.ExpiryDate
        }));
    }
}