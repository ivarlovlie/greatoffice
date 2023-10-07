using IOL.GreatOffice.Api.Models.Database;

namespace IOL.GreatOffice.Api.Services;

public class TenantService
{
    private readonly MainAppDatabase _database;
    private readonly ILogger<TenantService> _logger;

    public TenantService(MainAppDatabase database, ILogger<TenantService> logger) {
        _database = database;
        _logger = logger;
    }

    public Tenant CreateTenant(string name, Guid masterUserId, string email) {
        var tenant = new Tenant() {
            Name = name,
            Slug = Slug.Generate(true, name),
            MasterUserId = masterUserId,
            ContactEmail = email
        };

        var masterUserExists = _database.Users.Any(c => c.Id == tenant.MasterUserId);
        if (!masterUserExists) {
            _logger.LogError("Tried to create a new tenant with a non-existent master user: {masterUserId}", masterUserId);
            return default;
        }

        if (!email.IsValidEmailAddress()) {
            _logger.LogError("Tried to create a new tenant with an invalid email {contactEmail}", email);
            return default;
        }

        _database.Tenants.Add(tenant);
        _database.SaveChanges();
        return tenant;
    }

    public void AddUserToTenant(Guid userId, Guid tenantId) {
        var tenant = _database.Tenants.FirstOrDefault(c => c.Id == tenantId);
        if (tenant == default) {
            _logger.LogError("Tried adding user {userId} to tenant {tenantId} but the tenant was not found", userId, tenantId);
            return;
        }

        var user = _database.Users.FirstOrDefault(c => c.Id == userId);
        if (user == default) {
            _logger.LogError("Tried adding user {userId} to tenant {tenantId} but the user was not found", userId, tenantId);
            return;
        }

        if (tenant.Users.Any(c => c.Id == user.Id)) {
            _logger.LogDebug("User {userId} is already a part of tenant {tenantId}", userId, tenantId);
            return;
        }

        tenant.Users.Add(user);
        tenant.SetModified();
        _database.Tenants.Update(tenant);
        _database.SaveChanges();
        _logger.LogInformation("Added user {userId} to tenant {tenantId}", userId, tenantId);
    }
}