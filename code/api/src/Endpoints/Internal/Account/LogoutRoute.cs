namespace IOL.GreatOffice.Api.Endpoints.Internal.Account;

public class LogoutRoute : RouteBaseAsync.WithoutRequest.WithActionResult
{
    private readonly UserService _userService;

    public LogoutRoute(UserService userService) {
        _userService = userService;
    }

    /// <summary>
    /// Logout a user.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("~/_/account/logout")]
    public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default) {
        await _userService.LogOutUser(HttpContext, cancellationToken);
        return Ok();
    }
}