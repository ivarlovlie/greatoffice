namespace IOL.GreatOffice.Api.Data.Database;

public abstract class Base
{
    protected Base() {
        Id = Guid.NewGuid();
        CreatedAt = AppDateTime.UtcNow;
    }

    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? ModifiedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public bool Deleted { get; private set; }

    public void SetModified() => ModifiedAt = AppDateTime.UtcNow;

    public void SetDeleted() {
        Deleted = true;
        DeletedAt = AppDateTime.UtcNow;
    }
}