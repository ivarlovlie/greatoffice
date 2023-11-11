namespace IOL.GreatOffice.Api.Endpoints.Internal.Root;

public class ReadConfigurationRoute : RouteBaseSync.WithoutRequest.WithActionResult
{
    public ReadConfigurationRoute()
    {
    }

    [AllowAnonymous]
    [HttpGet("~/_/configuration")]
    public override ActionResult Handle()
    {
        return Content(JsonSerializer.Serialize(Program.AppConfiguration.GetPublicObject()), "application/json");
    }
}