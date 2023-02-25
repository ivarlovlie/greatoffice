namespace IOL.GreatOffice.Api.Data.Database;

public class Customer : BaseWithOwner
{
    public Customer() { }
    public Customer(LoggedInUserModel loggedInUserModel) : base(loggedInUserModel) { }

    public string CustomerNumber { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string PostalCode { get; set; }
    public string PostalCity { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string VATNumber { get; set; }
    public string ORGNumber { get; set; }
    public string DefaultReference { get; set; }
    public string Website { get; set; }
    public string Currency { get; set; }
    public Guid? OwnerId { get; set; }
    public User Owner { get; set; }
    public ICollection<CustomerGroup> Groups { get; set; }
    public ICollection<CustomerContact> Contacts { get; set; }
    public ICollection<CustomerEvent> Events { get; set; }
    public ICollection<Project> Projects { get; set; }
}