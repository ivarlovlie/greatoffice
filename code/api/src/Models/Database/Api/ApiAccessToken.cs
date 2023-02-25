namespace IOL.GreatOffice.Api.Data.Database;

public class ApiAccessToken : Base
{
    public User User { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool AllowRead { get; set; }
    public bool AllowCreate { get; set; }
    public bool AllowUpdate { get; set; }
    public bool AllowDelete { get; set; }
    public bool HasExpired => ExpiryDate < AppDateTime.UtcNow;
}