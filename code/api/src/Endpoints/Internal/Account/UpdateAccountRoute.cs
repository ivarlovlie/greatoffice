namespace IOL.GreatOffice.Api.Endpoints.Internal.Account;

public class UpdateAccountRoute : RouteBaseAsync.WithRequest<UpdateAccountRoute.Payload>.WithActionResult
{
    private readonly MainAppDatabase _database;
    private readonly IStringLocalizer<SharedResources> _localizer;

    public UpdateAccountRoute(MainAppDatabase database, IStringLocalizer<SharedResources> localizer) {
        _database = database;
        _localizer = localizer;
    }

    public class Payload
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    [HttpPost("~/_/account/update")]
    public override async Task<ActionResult> HandleAsync(Payload request, CancellationToken cancellationToken = default) {
        var user = _database.Users.SingleOrDefault(c => c.Id == LoggedInUser.Id);
        if (user == default) {
            await HttpContext.SignOutAsync();
            return Unauthorized();
        }

        if (request.Password.IsNullOrWhiteSpace() && request.Username.IsNullOrWhiteSpace()) {
            return KnownProblem(_localizer["Invalid request"], _localizer["No data was submitted"]);
        }

        var problem = new KnownProblemModel();

        if (request.Password.HasValue() && request.Password.Length < 6) {
            problem.AddError("password", _localizer["The new password must contain at least 6 characters"]);
        }

        if (request.Password.HasValue()) {
            user.HashAndSetPassword(request.Password);
        }

        if (request.Username.HasValue() && !request.Username.IsValidEmailAddress()) {
            problem.AddError("username", _localizer["The new username does not look like a valid email address"]);
        }

        if (problem.Errors.Any()) {
            problem.Title = _localizer["Invalid form"];
            problem.Subtitle = _localizer["One or more validation errors occured"];
            return KnownProblem(problem);
        }

        if (request.Username.HasValue()) {
            user.Username = request.Username.Trim();
        }

        await _database.SaveChangesAsync(cancellationToken);
        return Ok();
    }
}