namespace IOL.GreatOffice.Api.Models.Database;

public class TodoLabel : BaseWithOwner
{
	public string Name { get; set; }
	public string Color { get; set; }
	public Todo Todo { get; set; }
}
