namespace IOL.GreatOffice.Api.Models.Misc;

public class LoggedInUserModel
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public Guid TenantId { get; set; }
}