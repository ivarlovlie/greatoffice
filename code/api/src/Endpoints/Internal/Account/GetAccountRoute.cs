using IOL.GreatOffice.Api.Models.Database;

namespace IOL.GreatOffice.Api.Endpoints.Internal.Account;

public class GetAccountRoute : RouteBaseAsync.WithoutRequest.WithActionResult<LoggedInUserModel>
{
    private readonly MainAppDatabase _database;

    public GetAccountRoute(MainAppDatabase database) {
        _database = database;
    }

    [HttpGet("~/_/account")]
    public override async Task<ActionResult<LoggedInUserModel>> HandleAsync(CancellationToken cancellationToken = default) {
        var user = _database.Users
            .Select(x => new {x.Username, x.Id})
            .SingleOrDefault(c => c.Id == LoggedInUser.Id);
        if (user != default) {
            return Ok(new LoggedInUserModel {
                Id = LoggedInUser.Id,
                Username = LoggedInUser.Username
            });
        }

        await HttpContext.SignOutAsync();
        return Unauthorized();
    }
}