namespace IOL.GreatOffice.Api.Endpoints.V1.Projects;

public class CreateProjectRoute : RouteBaseAsync.WithRequest<CreateProjectPayload>.WithActionResult
{
    private readonly MainAppDatabase _database;
    private readonly IStringLocalizer<SharedResources> _localizer;

    public CreateProjectRoute(MainAppDatabase database, IStringLocalizer<SharedResources> localizer) {
        _database = database;
        _localizer = localizer;
    }

    [HttpPost("~/v{version:apiVersion}/projects/create")]
    public override async Task<ActionResult> HandleAsync(CreateProjectPayload request, CancellationToken cancellationToken = default) {
        var problem = new KnownProblemModel();

        if (request.Name.IsNullOrEmpty()) {
            problem.AddError("name", _localizer["Name is a required field"]);
        }

        var project = new Project(LoggedInUser) {
            Name = request.Name,
            Description = request.Description,
            Start = request.Start,
            Stop = request.Stop,
        };

        project.SetOwnerIds(default, LoggedInUser.TenantId);

        foreach (var customerId in request.CustomerIds) {
            var customer = _database.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == default) {
                problem.AddError("customer_" + customerId, _localizer["Customer not found"]);
                continue;
            }

            project.Customers.Add(customer);
        }

        foreach (var member in request.Members) {
            var user = _database.Users.FirstOrDefault(c => c.Id == member.UserId);
            if (user == default) {
                problem.AddError("members_" + member.UserId, _localizer["User not found"]);
                continue;
            }

            project.Members.Add(new ProjectMember() {
                Project = project,
                User = user,
                Role = member.Role
            });
        }

        if (problem.Errors.Any()) {
            problem.Title = _localizer["Invalid form"];
            problem.Subtitle = _localizer["One or more validation errors occured"];
            return KnownProblem(problem);
        }

        _database.Projects.Add(project);
        await _database.SaveChangesAsync(cancellationToken);
        return Ok();
    }
}

public class CreateProjectResponse
{ }

public class CreateProjectPayload
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Start { get; set; }
    public DateTime Stop { get; set; }
    public List<Guid> CustomerIds { get; set; }
    public List<ProjectMember> Members { get; set; }

    public class ProjectMember
    {
        public Guid UserId { get; set; }
        public ProjectRole Role { get; set; }
    }
}