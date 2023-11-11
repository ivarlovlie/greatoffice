namespace IOL.GreatOffice.Api.Models.Database;

public class CustomerGroupMembership : Base
{
    public Customer Customer { get; set; }
    public CustomerGroup Group { get; set; }
}