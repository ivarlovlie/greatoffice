namespace IOL.GreatOffice.Api.Endpoints.Internal.Root;

public class ReadConfigurationRoute : RouteBaseSync.WithoutRequest.WithActionResult
{
    private readonly VaultService _vaultService;

    public ReadConfigurationRoute(VaultService vaultService)
    {
        _vaultService = vaultService;
    }

    [AllowAnonymous]
    [HttpGet("~/_/configuration")]
    public override ActionResult Handle()
    {
        var config = _vaultService.GetCurrentAppConfiguration();
        return Content(JsonSerializer.Serialize(config.GetPublicObject()), "application/json");
    }
}