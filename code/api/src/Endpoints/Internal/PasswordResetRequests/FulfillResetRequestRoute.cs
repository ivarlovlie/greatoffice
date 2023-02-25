namespace IOL.GreatOffice.Api.Endpoints.Internal.PasswordResetRequests;

public class FulfillResetRequestRoute : RouteBaseAsync.WithRequest<FulfillResetRequestRoute.Payload>.WithActionResult
{
    private readonly IStringLocalizer<SharedResources> _localizer;
    private readonly PasswordResetService _passwordResetService;

    public FulfillResetRequestRoute(PasswordResetService passwordResetService, IStringLocalizer<SharedResources> localizer) {
        _passwordResetService = passwordResetService;
        _localizer = localizer;
    }

    public class Payload
    {
        public Guid Id { get; set; }
        public string NewPassword { get; set; }
    }

    [AllowAnonymous]
    [HttpPost("~/_/password-reset-request/fulfill")]
    public override async Task<ActionResult> HandleAsync(Payload request, CancellationToken cancellationToken = default) {
        if (request.NewPassword.Length < 6) {
            return KnownProblem(_localizer["Invalid form"],
                _localizer["One or more fields is invalid"],
                new Dictionary<string, string[]> {{"newPassword", new string[] {_localizer["The new password needs to be atleast 6 characters"]}}}
            );
        }

        return await _passwordResetService.FulfillRequestAsync(request.Id, request.NewPassword, cancellationToken) switch {
            FulfillPasswordResetRequestResult.REQUEST_NOT_FOUND => NotFound(),
            FulfillPasswordResetRequestResult.USER_NOT_FOUND => NotFound(),
            FulfillPasswordResetRequestResult.FULFILLED => Ok(),
            _ => StatusCode(500)
        };
    }
}