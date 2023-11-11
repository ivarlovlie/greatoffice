namespace IOL.GreatOffice.Api.Endpoints.Internal.Root;

public class ValidateRoute : RouteBaseSync.WithRequest<ValidateRoute.QueryParams>.WithActionResult
{
    private readonly EmailValidationService _emailValidation;
    private readonly string CanonicalFrontendUrl;
    private readonly ILogger<ValidateRoute> _logger;

    public ValidateRoute(EmailValidationService emailValidation, ILogger<ValidateRoute> logger)
    {
        _emailValidation = emailValidation;
        _logger = logger;
        CanonicalFrontendUrl = Program.AppConfiguration.CANONICAL_FRONTEND_URL;
    }

    public class QueryParams
    {
        [FromQuery]
        public Guid Id { get; set; }
    }

    [HttpGet("~/_/validate")]
    public override ActionResult Handle([FromQuery] QueryParams request)
    {
        var isFulfilled = _emailValidation.FulfillEmailValidationRequest(request.Id, LoggedInUser.Id);
        if (!isFulfilled)
        {
            _logger.LogError("Email validation fulfillment failed for request {requestId} and user {userId}", request.Id, LoggedInUser.Id);
            return StatusCode(400, $"""
<html>
<body>
<h3>The validation could not be completed</h3>
<p>We are working on fixing this, in the meantime, have patience.</p>
<a href="{CanonicalFrontendUrl}">Click here to go back to {CanonicalFrontendUrl}</a>
</body>
""");
        }

        return Redirect(CanonicalFrontendUrl + "/portal?msg=emailValidated");
    }
}