namespace IOL.GreatOffice.Api.Endpoints.Internal.Root;

public class IsAuthenticatedRoute : RouteBaseSync.WithoutRequest.WithActionResult
{
    [Authorize]
    [HttpGet("~/_/is-authenticated")]
    public override ActionResult Handle() {
        return Ok();
    }
}