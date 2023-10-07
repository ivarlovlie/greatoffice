using IOL.GreatOffice.Api.Models.Database;

namespace IOL.GreatOffice.Api.Endpoints.V1.ApiTokens;

public class DeleteTokenRoute : RouteBaseSync.WithRequest<Guid>.WithActionResult
{
    private readonly MainAppDatabase _database;
    private readonly ILogger<DeleteTokenRoute> _logger;

    public DeleteTokenRoute(MainAppDatabase database, ILogger<DeleteTokenRoute> logger) {
        _database = database;
        _logger = logger;
    }

    /// <summary>
    /// Delete an api token, rendering it unusable
    /// </summary>
    /// <param name="id">Id of the token to delete</param>
    /// <returns>Nothing</returns>
    [ApiVersion(ApiSpecV1.VERSION_STRING)]
    [HttpDelete("~/v{version:apiVersion}/api-tokens/delete")]
    public override ActionResult Handle(Guid id) {
        var token = _database.AccessTokens.SingleOrDefault(c => c.Id == id);
        if (token == default) {
            _logger.LogWarning("A deletion request of an already deleted (maybe) api token was received.");
            return NotFound();
        }

        _database.AccessTokens.Remove(token);
        _database.SaveChanges();
        return Ok();
    }
}