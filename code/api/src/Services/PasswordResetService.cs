namespace IOL.GreatOffice.Api.Services;

public class PasswordResetService
{
    private readonly MainAppDatabase _database;
    private readonly MailService _mailService;
    private readonly ILogger<PasswordResetService> _logger;
    private readonly IStringLocalizer<SharedResources> _localizer;

    public PasswordResetService(
        MainAppDatabase database,
        ILogger<PasswordResetService> logger,
        MailService mailService, IStringLocalizer<SharedResources> localizer)
    {
        _database = database;
        _logger = logger;
        _mailService = mailService;
        _localizer = localizer;
    }

    public async Task<PasswordResetRequest> GetRequestAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var request = await _database.PasswordResetRequests
            .Include(c => c.User)
            .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
        if (request == default)
        {
            return default;
        }

        _logger.LogInformation($"Found password reset request for user: {request.User.Username}, expires at {request.ExpirationDate} (in {request.ExpirationDate.Subtract(AppDateTime.UtcNow).Minutes} minutes).");
        return request;
    }

    public async Task<FulfillPasswordResetRequestResult> FulfillRequestAsync(Guid id, string newPassword, CancellationToken cancellationToken = default)
    {
        var request = await GetRequestAsync(id, cancellationToken);
        if (request == default) return FulfillPasswordResetRequestResult.REQUEST_NOT_FOUND;
        var user = _database.Users.FirstOrDefault(c => c.Id == request.User.Id);
        if (user == default) return FulfillPasswordResetRequestResult.USER_NOT_FOUND;
        user.HashAndSetPassword(newPassword);
        _database.Users.Update(user);
        await _database.SaveChangesAsync(cancellationToken);
        _logger.LogInformation($"Fullfilled password reset request for user: {request.User.Username}");
        await DeleteRequestsForUserAsync(user.Id, cancellationToken);
        return FulfillPasswordResetRequestResult.FULFILLED;
    }

    public async Task AddRequestAsync(User user, TimeZoneInfo requestTz, CancellationToken cancellationToken = default)
    {
        await DeleteRequestsForUserAsync(user.Id, cancellationToken);
        var request = new PasswordResetRequest(user);
        _database.PasswordResetRequests.Add(request);
        await _database.SaveChangesAsync(cancellationToken);
        var zonedExpirationDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(request.ExpirationDate, requestTz.Id);
        var message = new MailService.PostmarkEmail()
        {
            To = request.User.Username,
            Subject = _localizer["Reset password - Greatoffice"],
            TextBody = _localizer["""
Hi {0},

Go to the following link to set a new password.

{1}/reset-password/{2}

The link expires at {3}.
If you did not request a password reset, no action is required.
""", user.DisplayName(true), Program.AppConfiguration.CANONICAL_FRONTEND_URL, request.Id, zonedExpirationDate.ToString("yyyy-MM-dd hh:mm")]
        };

        await Task.Run(() =>
        {
            _mailService.SendMailAsync(message).ConfigureAwait(false);
            _logger.LogInformation($"Added password reset request for user: {request.User.Username}, expires in {request.ExpirationDate.Subtract(AppDateTime.UtcNow)}.");
        },
            cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteRequestsForUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var requestsToRemove = _database.PasswordResetRequests.Where(c => c.UserId == userId).ToList();
        if (!requestsToRemove.Any()) return;
        _database.PasswordResetRequests.RemoveRange(requestsToRemove);
        await _database.SaveChangesAsync(cancellationToken);
        _logger.LogInformation($"Deleted {requestsToRemove.Count} password reset requests for user: {userId}.");
    }

    public async Task DeleteStaleRequestsAsync(CancellationToken cancellationToken = default)
    {
        var deleteCount = 0;
        foreach (var request in _database.PasswordResetRequests.Where(c => c.IsExpired))
        {
            if (!request.IsExpired)
            {
                continue;
            }

            _database.PasswordResetRequests.Remove(request);
            deleteCount++;
            _logger.LogInformation($"Marking password reset request with id: {request.Id} for deletion, expiration date was {request.ExpirationDate}.");
        }

        await _database.SaveChangesAsync(cancellationToken);
        _logger.LogInformation($"Deleted {deleteCount} stale password reset requests.");
    }
}