namespace IOL.GreatOffice.Api.Endpoints.Internal.PasswordResetRequests;

public class IsResetRequestValidRoute : RouteBaseAsync.WithRequest<Guid>.WithActionResult<IsResetRequestValidRoute.ResponseModel>
{
    private readonly PasswordResetService _passwordResetService;

    public IsResetRequestValidRoute(PasswordResetService passwordResetService) {
        _passwordResetService = passwordResetService;
    }

    public class ResponseModel
    {
        public ResponseModel(bool isValid) {
            IsValid = isValid;
        }

        public bool IsValid { get; }
    }

    [AllowAnonymous]
    [HttpGet("~/_/password-reset-request/is-valid")]
    public override async Task<ActionResult<ResponseModel>> HandleAsync(Guid id, CancellationToken cancellationToken = default) {
        var request = await _passwordResetService.GetRequestAsync(id, cancellationToken);
        return Ok(request == default ? new ResponseModel(false) : new ResponseModel(!request.IsExpired));
    }
}