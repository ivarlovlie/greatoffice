namespace IOL.GreatOffice.Api.Models.Database;

public class CustomerGroup : BaseWithOwner
{
    public string Name { get; set; }
    public ICollection<Customer> Customers { get; set; }
}