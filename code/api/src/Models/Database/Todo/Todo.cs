namespace IOL.GreatOffice.Api.Data.Database;

public class Todo : BaseWithOwner
{
    public string PublicId { get; set; }
    public Guid? AssignedToId { get; set; }
    public Guid? ClosedById { get; set; }
    public Guid CollectionId { get; set; }
    public DateTime? ClosedAt { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<TodoLabel> Labels { get; set; }
    public ICollection<TodoComment> Comments { get; set; }
    public User AssignedTo { get; set; }
    public User ClosedBy { get; set; }
    public TodoCollection Collection { get; set; }
}