namespace IOL.GreatOffice.Api.Models.Database;

public class ProjectMember : Base
{
    public Project Project { get; set; }
    public User User { get; set; }
    public ProjectRole Role { get; set; }
}