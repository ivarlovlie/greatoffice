namespace IOL.GreatOffice.Api.Endpoints.Internal.Root;

public class RefreshConfigurationRoute : RouteBaseAsync.WithoutRequest.WithoutResult
{
    private readonly VaultService _vaultService;

    public RefreshConfigurationRoute(VaultService vaultService) {
        _vaultService = vaultService;
    }

    [HttpGet("~/_/refresh-configuration")]
    public override async Task HandleAsync(CancellationToken cancellationToken = default) {
        await _vaultService.RefreshCurrentAppConfigurationAsync();
    }
}