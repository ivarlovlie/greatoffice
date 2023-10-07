using IOL.GreatOffice.Api.Models.Database;

namespace IOL.GreatOffice.Api.Services;

public class UserService
{
    private readonly PasswordResetService _passwordResetService;
    private readonly ILogger<UserService> _logger;
    private readonly MainAppDatabase _database;

    public UserService(PasswordResetService passwordResetService, ILogger<UserService> logger, MainAppDatabase database) {
        _passwordResetService = passwordResetService;
        _logger = logger;
        _database = database;
    }

    public async Task LogInUserAsync(HttpContext httpContext, User user, bool persist = false, CancellationToken cancellationToken = default) {
        var identity = new ClaimsIdentity(user.DefaultClaims(), CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        var authenticationProperties = new AuthenticationProperties {
            AllowRefresh = true,
            IssuedUtc = DateTimeOffset.UtcNow,
        };

        if (persist) {
            authenticationProperties.ExpiresUtc = DateTimeOffset.UtcNow.AddMonths(6);
            authenticationProperties.IsPersistent = true;
        }

        await httpContext.SignInAsync(principal, authenticationProperties);
        await _passwordResetService.DeleteRequestsForUserAsync(user.Id, cancellationToken);
        _logger.LogInformation("Logged in user {userId}", user.Id);
    }

    public async Task LogOutUser(HttpContext httpContext, CancellationToken cancellationToken = default) {
        await httpContext.SignOutAsync();
        _logger.LogInformation("Logged out user {userId}", httpContext.User.FindFirst(AppClaims.USER_ID));
    }

    public async Task MarkUserAsDeleted(Guid userId, Guid actorId) {
        var user = _database.Users.FirstOrDefault(c => c.Id == userId);
        if (user == default) {
            _logger.LogInformation("Tried to delete unknown user {userId}", userId);
            return;
        }

        if (user.Username is "demo@greatoffice.app" or "tester@greatoffice.app") {
            _logger.LogInformation("Not deleting user {userId}, because it's username is {username}", user.Id, user.Username);
            return;
        }

        await _passwordResetService.DeleteRequestsForUserAsync(user.Id);
        user.SetDeleted(actorId);
        await _database.SaveChangesAsync();
    }
}