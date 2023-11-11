namespace IOL.GreatOffice.Api.Models.Database;

public class Tenant : BaseWithOwner
{
    public string Slug { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ContactEmail { get; set; }
    public Guid MasterUserId { get; set; }
    public string MasterUserPassword { get; set; }
    public ICollection<User> Users { get; set; }
}