namespace IOL.GreatOffice.Api.Models.Database;

public class TodoCollectionAccessControl : Base
{
    public TodoCollection Collection { get; set; }
    public User User { get; set; }
    public Guid? UserId { get; set; }
    public bool CanBrowse { get; set; }
    public bool CanSubmit { get; set; }
    public bool CanComment { get; set; }
    public bool CanEdit { get; set; }
}