namespace IOL.GreatOffice.Api.Jobs;

public class VaultTokenRenewalJob : IJob
{
    private readonly ILogger<VaultTokenRenewalJob> _logger;
    private readonly VaultService _vaultService;

    public VaultTokenRenewalJob(ILogger<VaultTokenRenewalJob> logger, VaultService vaultService) {
        _logger = logger;
        _vaultService = vaultService;
    }

    public async Task Execute(IJobExecutionContext context) {
        _logger.LogInformation("Starting vault token renewal");
        var renew = await _vaultService.RenewTokenAsync();
        if (renew == default) {
            _logger.LogCritical("Renewal did not succeed");
            return;
        }

        var token = await _vaultService.LookupTokenAsync();
        _logger.LogInformation("Token was renewed, new expire time {expires}", token.Data.ExpireTime);
    }
}