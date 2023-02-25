using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace IOL.GreatOffice.Api.Endpoints.Internal.Account;

public class CreateAccountRoute : RouteBaseAsync.WithRequest<CreateAccountRoute.Payload>.WithActionResult
{
    private readonly MainAppDatabase _database;
    private readonly UserService _userService;
    private readonly IStringLocalizer<SharedResources> _localizer;
    private readonly EmailValidationService _emailValidation;
    private readonly ILogger<CreateAccountRoute> _logger;
    private readonly TenantService _tenantService;

    public CreateAccountRoute(UserService userService, MainAppDatabase database, IStringLocalizer<SharedResources> localizer, EmailValidationService emailValidation, TenantService tenantService, ILogger<CreateAccountRoute> logger) {
        _userService = userService;
        _database = database;
        _localizer = localizer;
        _emailValidation = emailValidation;
        _tenantService = tenantService;
        _logger = logger;
    }

    public class Payload
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    [AllowAnonymous]
    [HttpPost("~/_/account/create")]
    public override async Task<ActionResult> HandleAsync(Payload request, CancellationToken cancellationToken = default) {
        var problem = new KnownProblemModel();
        var username = request.Username.Trim();
        if (username.IsValidEmailAddress() == false) {
            problem.AddError("username", _localizer["{username} does not look like a valid email", username]);
        } else if (_database.Users.FirstOrDefault(c => c.Username == username) != default) {
            problem.AddError("username", _localizer["There is already a user registered with username: {username}", username]);
        }

        if (request.Password.Length < 6) {
            problem.AddError("password", _localizer["The password requires 6 or more characters."]);
        }

        if (problem.Errors.Any()) {
            problem.Title = _localizer["Invalid form"];
            problem.Subtitle = _localizer["One or more fields is invalid"];
            return KnownProblem(problem);
        }

        var user = new User(username);
        var tenant = _tenantService.CreateTenant(user.DisplayName() + "'s tenant", user.Id, user.Username);
        if (tenant == default) {
            _logger.LogError("Not creating new user because the tenant could not be created");
            return KnownProblem(_localizer["Could not create your account, try again soon."]);
        }

        user.HashAndSetPassword(request.Password);
        _database.Users.Add(user);
        await _database.SaveChangesAsync(cancellationToken);
        await _userService.LogInUserAsync(HttpContext, user, false, cancellationToken);
        await _emailValidation.SendValidationEmailAsync(user);
        return Ok();
    }
}