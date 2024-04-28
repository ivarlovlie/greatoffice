namespace IOL.GreatOffice.Api.Models.Database;

/// <summary>
/// Base class for all entities with ownership.
/// </summary>
public abstract class BaseWithOwner : Base
{
    protected BaseWithOwner() { }

    protected BaseWithOwner(Guid createdBy) {
        CreatedBy = createdBy;
    }

    protected BaseWithOwner(LoggedInUserModel loggedInUser) {
        CreatedBy = loggedInUser.Id;
    }

    public Guid? UserId { get; private set; }
    public Guid? TenantId { get; private set; }
    public Guid? ModifiedBy { get; private set; }
    public Guid? CreatedBy { get; private set; }
    public Guid? DeletedBy { get; private set; }
    public User OwningUser { get; set; }
    public Tenant OwningTenant { get; set; }

    public void SetDeleted(Guid userId) {
        DeletedBy = userId;
        base.SetDeleted();
    }

    public void SetModified(Guid userId) {
        ModifiedBy = userId;
        base.SetModified();
    }

    public void SetOwnerIds(Guid userId = default, Guid tenantId = default) {
        if (tenantId != default) TenantId = tenantId;
        if (userId != default) UserId = userId;
    }
}