namespace IOL.GreatOffice.Api.Data.Database;

public class ProjectLabel : BaseWithOwner
{
	public string Value { get; set; }
	public string Color { get; set; }
	public Project Project { get; set; }
}
