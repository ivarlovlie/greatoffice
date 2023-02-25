namespace IOL.GreatOffice.Api.Endpoints.Internal.Account;

public class DeleteAccountRoute : RouteBaseAsync.WithoutRequest.WithActionResult
{
    private readonly UserService _userService;

    public DeleteAccountRoute(UserService userService) {
        _userService = userService;
    }

    [HttpDelete("~/_/account/delete")]
    public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default) {
        await _userService.LogOutUser(HttpContext, cancellationToken);
        await _userService.MarkUserAsDeleted(LoggedInUser.Id, LoggedInUser.Id);
        return Ok();
    }
}