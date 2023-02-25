namespace IOL.GreatOffice.Api.Endpoints.Internal.Root;

public class RefreshConfigurationRoute : RouteBaseSync.WithoutRequest.WithoutResult
{
    private readonly VaultService _vaultService;

    public RefreshConfigurationRoute(VaultService vaultService) {
        _vaultService = vaultService;
    }

    [HttpGet("~/_/refresh-configuration")]
    public override void Handle() {
        _vaultService.RefreshCurrentAppConfigurationAsync();
    }
}