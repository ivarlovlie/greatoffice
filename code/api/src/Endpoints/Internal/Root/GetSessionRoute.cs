using IOL.GreatOffice.Api.Models.Database;

namespace IOL.GreatOffice.Api.Endpoints.Internal.Root;

public class GetSessionRoute : RouteBaseSync.WithoutRequest.WithActionResult<GetSessionRoute.SessionResponse>
{
    private readonly MainAppDatabase _database;
    private readonly ILogger<GetSessionRoute> _logger;

    public GetSessionRoute(MainAppDatabase database, ILogger<GetSessionRoute> logger) {
        _database = database;
        _logger = logger;
    }

    public class SessionResponse
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public Guid UserId { get; set; }
        public SessionTenant CurrentTenant { get; set; }
        public List<SessionTenant> AvailableTenants { get; set; }

        public class SessionTenant
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }

    [Authorize]
    [HttpGet("~/_/session-data")]
    public override ActionResult<SessionResponse> Handle() {
        var user = _database.Users.Include(c => c.Tenants)
            .Select(c => new User() {
                Id = c.Id,
                Username = c.Username,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Tenants = c.Tenants
            }).FirstOrDefault(c => c.Id == LoggedInUser.Id);

        if (user == default) {
            return NotFound();
        }

        var currentTenant = user.Tenants.FirstOrDefault(c => c.Id == LoggedInUser.TenantId);
        if (currentTenant == default) {
            _logger.LogInformation("Could not find current tenant ({tenantId}) for user {userId}", LoggedInUser.TenantId, LoggedInUser.Id);
            return NotFound();
        }

        return Ok(new SessionResponse() {
            Username = user.Username,
            DisplayName = user.DisplayName(),
            UserId = user.Id,
            CurrentTenant = new SessionResponse.SessionTenant() {
                Id = currentTenant.Id,
                Name = currentTenant.Name
            },
            AvailableTenants = user.Tenants.Select(c => new SessionResponse.SessionTenant() {
                Id = c.Id,
                Name = c.Name
            }).ToList()
        });
    }
}