namespace IOL.GreatOffice.Api.Models.Database;

public class PasswordResetRequest
{
	public PasswordResetRequest() { }

	public PasswordResetRequest(User user)
	{
		CreatedAt = AppDateTime.UtcNow;
		Id = Guid.NewGuid();
		User = user;
	}

	public Guid Id { get; set; }
	public Guid UserId { get; set; }
	public User User { get; set; }
	public DateTime CreatedAt { get; set; }

	[NotMapped]
	public DateTime ExpirationDate => CreatedAt.AddMinutes(15);

	[NotMapped]
	public bool IsExpired => DateTime.Compare(ExpirationDate, AppDateTime.UtcNow) < 0;
}
