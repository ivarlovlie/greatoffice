namespace IOL.GreatOffice.Api.Jobs;

public class AccessTokenCleanupJob : IJob
{
	private readonly ILogger<AccessTokenCleanupJob> _logger;
	private readonly MainAppDatabase _context;

	public AccessTokenCleanupJob(ILogger<AccessTokenCleanupJob> logger, MainAppDatabase context) {
		_logger = logger;
		_context = context;
	}

	public Task Execute(IJobExecutionContext context) {
		var staleTokens = _context.AccessTokens.Where(c => c.ExpiryDate < AppDateTime.UtcNow).ToList();
		if (staleTokens.IsNullOrEmpty()) return Task.CompletedTask;
		_logger.LogInformation("Removing {0} stale tokens", staleTokens.Count());
		_context.AccessTokens.RemoveRange(staleTokens);
		return Task.CompletedTask;
	}
}
