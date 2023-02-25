namespace IOL.GreatOffice.Api.Endpoints.V1.Customers;

public class CreateCustomerRoute : RouteBaseAsync.WithRequest<CreateCustomerPayload>.WithActionResult
{
    private readonly MainAppDatabase _database;
    private readonly ILogger<CreateCustomerRoute> _logger;
    private readonly IStringLocalizer<SharedResources> _localizer;

    public CreateCustomerRoute(MainAppDatabase database, ILogger<CreateCustomerRoute> logger, IStringLocalizer<SharedResources> localizer) {
        _database = database;
        _logger = logger;
        _localizer = localizer;
    }

    [HttpPost("~/v{version:apiVersion}/customers/create")]
    public override async Task<ActionResult> HandleAsync(CreateCustomerPayload request, CancellationToken cancellationToken = default) {
        var problem = new KnownProblemModel();
        if (request.Name.Trim().IsNullOrEmpty()) problem.AddError("name", _localizer["Name is a required field"]);
        if (problem.Errors.Any()) {
            problem.Title = _localizer["Invalid form"];
            problem.Subtitle = _localizer["One or more validation errors occured"];
            return KnownProblem(problem);
        }

        var customer = new Customer(LoggedInUser) {
            CustomerNumber = request.CustomerNumber,
            Name = request.Name,
            Description = request.Description,
            Address1 = request.Address1,
            Address2 = request.Address2,
            Country = request.Country,
            Currency = request.Currency,
            Email = request.Email,
            Phone = request.Phone,
            PostalCity = request.PostalCity,
            PostalCode = request.PostalCode,
            VATNumber = request.VATNumber,
            ORGNumber = request.ORGNumber,
            DefaultReference = request.DefaultReference,
            Website = request.Website
        };
        customer.SetOwnerIds(default, LoggedInUser.TenantId);
        _database.Customers.Add(customer);
        await _database.SaveChangesAsync(cancellationToken);
        return Ok();
    }
}

public class CreateCustomerPayload
{
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
}