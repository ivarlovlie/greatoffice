namespace IOL.GreatOffice.Api.Data.Database;

public class CustomerEvent : BaseWithOwner
{
	public Customer Customer { get; set; }
	public string Title { get; set; }
	public string Note { get; set; }
}
