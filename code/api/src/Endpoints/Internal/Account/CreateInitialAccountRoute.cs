using IOL.GreatOffice.Api.Models.Database;

namespace IOL.GreatOffice.Api.Endpoints.Internal.Account;

public class CreateInitialAccountRoute : RouteBaseAsync.WithoutRequest.WithActionResult
{
    private readonly MainAppDatabase _database;
    private readonly UserService _userService;

    public CreateInitialAccountRoute(MainAppDatabase database, UserService userService) {
        _database = database;
        _userService = userService;
    }

    /// <summary>
    /// Create an initial user account.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("~/_/account/create-initial")]
    public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default) {
        if (_database.Users.Any()) {
            return NotFound();
        }

        var user = new User("admin@ivarlovlie.no");
        user.HashAndSetPassword("ivar123");
        _database.Users.Add(user);
        await _database.SaveChangesAsync(cancellationToken);
        await _userService.LogInUserAsync(HttpContext, user, cancellationToken: cancellationToken);
        return Redirect("/");
    }
}