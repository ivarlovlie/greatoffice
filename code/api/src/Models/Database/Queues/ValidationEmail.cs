namespace IOL.GreatOffice.Api.Models.Database;

public class ValidationEmail
{
    public Guid Id { get; set; }
    public DateTime EmailSentAt { get; set; }
    public Guid UserId { get; set; }
}