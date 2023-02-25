namespace IOL.GreatOffice.Api.Data.Database;

public class User : Base
{
    public User() { }

    public User(string username) {
        Username = username;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime EmailLastValidated { get; set; }
    public ICollection<Tenant> Tenants { get; set; }
    public Guid? DeletedBy { get; set; }

    public string DisplayName(bool isForGreeting = false) {
        if (!isForGreeting && FirstName.HasValue() && LastName.HasValue()) return FirstName + " " + LastName;
        return FirstName.HasValue() ? FirstName : Username ?? Email;
    }

    public void HashAndSetPassword(string password) {
        Password = PasswordHelper.HashPassword(password);
    }

    public bool VerifyPassword(string password) {
        return PasswordHelper.Verify(password, Password);
    }

    public void SetDeleted(Guid userId) {
        base.SetDeleted();
        DeletedBy = userId;
    }

    public IEnumerable<Claim> DefaultClaims() {
        return new Claim[] {
            new(AppClaims.USER_ID, Id.ToString()),
            new(AppClaims.NAME, Username),
        };
    }
}