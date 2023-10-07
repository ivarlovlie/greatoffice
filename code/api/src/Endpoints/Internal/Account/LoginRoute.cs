using IOL.GreatOffice.Api.Models.Database;

namespace IOL.GreatOffice.Api.Endpoints.Internal.Account;

public class LoginRoute : RouteBaseAsync.WithRequest<LoginRoute.Payload>.WithActionResult
{
    private readonly MainAppDatabase _database;
    private readonly UserService _userService;
    private readonly IStringLocalizer<SharedResources> _localizer;

    public LoginRoute(MainAppDatabase database, UserService userService, IStringLocalizer<SharedResources> localizer) {
        _database = database;
        _userService = userService;
        _localizer = localizer;
    }

    public class Payload
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Persist { get; set; }
    }

    [AllowAnonymous]
    [HttpPost("~/_/account/login")]
    public override async Task<ActionResult> HandleAsync(Payload request, CancellationToken cancellationToken = default) {
        var user = _database.Users.FirstOrDefault(u => u.Username == request.Username);
        if (user == default || !user.VerifyPassword(request.Password)) {
            return KnownProblem(_localizer["Invalid username or password"]);
        }

        if (user.Deleted) {
            return KnownProblem(_localizer["This user is deleted, please contact support@greatoffice.life if you think this is an error"]);
        }

        await _userService.LogInUserAsync(HttpContext, user, request.Persist, cancellationToken);
        return Ok();
    }
}