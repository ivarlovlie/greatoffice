namespace IOL.GreatOffice.Api.Services;

public class EmailValidationService
{
    private readonly IStringLocalizer<SharedResources> _localizer;
    private readonly MainAppDatabase _database;
    private readonly MailService _mailService;
    private readonly ILogger<EmailValidationService> _logger;
    private readonly string EmailValidationUrl;

    public EmailValidationService(IStringLocalizer<SharedResources> localizer, MainAppDatabase database, MailService mailService, ILogger<EmailValidationService> logger, VaultService vaultService) {
        _localizer = localizer;
        _database = database;
        _mailService = mailService;
        _logger = logger;
        var configuration = vaultService.GetCurrentAppConfiguration();
        EmailValidationUrl = configuration.CANONICAL_BACKEND_URL + "/_/validate";
    }

    public bool FulfillEmailValidationRequest(Guid id, Guid userId) {
        var item = _database.ValidationEmails.FirstOrDefault(c => c.Id == id);
        if (item == default) {
            _logger.LogDebug("Did not find email validation request with id: {requestId}", id);
            return false;
        }

        if (item.UserId != userId) {
            _logger.LogInformation("An unknown user tried to validate the email validation request {requestId}", id);
            return false;
        }

        var user = _database.Users.FirstOrDefault(c => c.Id == item.UserId);
        if (user == default) {
            _database.ValidationEmails.Remove(item);
            _database.SaveChanges();
            _logger.LogInformation("Deleting request {requestId} because user does not exist anymore", id);
            return false;
        }

        user.EmailLastValidated = AppDateTime.UtcNow;
        _database.ValidationEmails.Remove(item);
        _database.Users.Update(user);
        _database.SaveChanges();
        _logger.LogInformation("Successfully validated the email for user {userId}", user.Id);
        return true;
    }

    public async Task SendValidationEmailAsync(User user) {
        var queueItem = new ValidationEmail() {
            UserId = user.Id,
            Id = Guid.NewGuid()
        };
        var email = new MailService.PostmarkEmail() {
            To = user.Username,
            Subject = _localizer["Greatoffice Email Validation"],
            TextBody = _localizer["""
Hello {0},

Validate your email address by opening this link in a browser {1}
""", user.DisplayName(true), EmailValidationUrl + "?id=" + queueItem.Id]
        };
        queueItem.EmailSentAt = AppDateTime.UtcNow;
        _database.ValidationEmails.Add(queueItem);
        await _database.SaveChangesAsync();
        Task.Run(async () => await _mailService.SendMailAsync(email));
    }
}