namespace IOL.GreatOffice.Api.Data.Database;

public class TodoComment : BaseWithOwner
{
    public string Value { get; set; }
    public Todo Todo { get; set; }
    public TodoClosingStatement? ClosingStatement { get; set; }
}