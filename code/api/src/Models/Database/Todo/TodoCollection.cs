namespace IOL.GreatOffice.Api.Models.Database;

public class TodoCollection : BaseWithOwner
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TodoVisibility Visibility { get; set; }
    public Guid? ProjectId { get; set; }
    public Project Project { get; set; }
    public ICollection<TodoCollectionAccessControl> AccessControls { get; set; }
}