namespace IOL.GreatOffice.Api.Models.Database;

public class CustomerContact : BaseWithOwner
{
	public Customer Customer { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string Phone { get; set; }
	public string WorkTitle { get; set; }
	public string Note { get; set; }
}
