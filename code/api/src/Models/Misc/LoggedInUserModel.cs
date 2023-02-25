namespace IOL.GreatOffice.Api.Data.Models;

public class LoggedInUserModel
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public Guid TenantId { get; set; }
}