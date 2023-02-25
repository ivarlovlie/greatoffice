namespace IOL.GreatOffice.Api.Data.Database;

public class Project : BaseWithOwner
{
    public Project() { }

    public Project(LoggedInUserModel loggedInUserModel) : base(loggedInUserModel) { }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? Stop { get; set; }
    public ICollection<Customer> Customers { get; set; }
    public ICollection<ProjectMember> Members { get; set; }
    public ICollection<ProjectLabel> Labels { get; set; }
}