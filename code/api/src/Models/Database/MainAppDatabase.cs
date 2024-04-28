using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;

namespace IOL.GreatOffice.Api.Models.Database;

public class MainAppDatabase : DbContext, IDataProtectionKeyContext
{
    public MainAppDatabase(DbContextOptions<MainAppDatabase> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<PasswordResetRequest> PasswordResetRequests { get; set; }
    public DbSet<ApiAccessToken> AccessTokens { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectLabel> ProjectLabels { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerContact> CustomersContacts { get; set; }
    public DbSet<CustomerEvent> CustomerEvents { get; set; }
    public DbSet<CustomerGroup> CustomerGroups { get; set; }
    public DbSet<TodoLabel> TodoLabels { get; set; }
    public DbSet<TodoCollectionAccessControl> TodoProjectAccessControls { get; set; }
    public DbSet<TodoCollection> TodoProjects { get; set; }
    public DbSet<TodoComment> TodoComments { get; set; }
    public DbSet<Todo> Todos { get; set; }
    public DbSet<ValidationEmail> ValidationEmails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<User>(e => {
            e.HasMany(n => n.Tenants);
            e.ToTable("users");
        });
        modelBuilder.Entity<PasswordResetRequest>(e => {
            e.HasOne(c => c.User);
            e.ToTable("password_reset_requests");
        });
        modelBuilder.Entity<ApiAccessToken>(e => {
            e.HasOne(n => n.User);
            e.ToTable("api_access_tokens");
        });
        modelBuilder.Entity<Tenant>(e => {
            e.HasMany(n => n.Users);
            e.ToTable("tenants");
        });
        modelBuilder.Entity<Project>(e => {
            e.HasMany(n => n.Members);
            e.HasMany(n => n.Customers);
            e.ToTable("projects");
        });
        modelBuilder.Entity<ProjectMember>(e => {
            e.HasOne(n => n.Project);
            e.HasOne(n => n.User);
            e.ToTable("project_members");
        });
        modelBuilder.Entity<ProjectLabel>(e => {
            e.HasOne(n => n.Project);
            e.ToTable("project_labels");
        });
        modelBuilder.Entity<Customer>(e => {
            e.HasOne(n => n.Owner);
            e.HasMany(n => n.Events);
            e.HasMany(n => n.Contacts);
            e.HasMany(n => n.Groups);
            e.HasMany(n => n.Projects);
            e.ToTable("customers");
        });
        modelBuilder.Entity<CustomerContact>(e => {
            e.HasOne(n => n.Customer);
            e.ToTable("customer_contacts");
        });
        modelBuilder.Entity<CustomerEvent>(e => {
            e.HasOne(n => n.Customer);
            e.ToTable("customer_events");
        });
        modelBuilder.Entity<CustomerGroup>(e => {
            e.HasMany(n => n.Customers);
            e.ToTable("customer_groups");
        });
        modelBuilder.Entity<Todo>(e => {
            e.HasOne(n => n.Collection);
            e.HasOne(n => n.AssignedTo);
            e.HasOne(n => n.ClosedBy);
            e.HasMany(n => n.Labels);
            e.HasMany(n => n.Comments);
            e.ToTable("todos");
        });
        modelBuilder.Entity<TodoCollection>(e => {
            e.HasOne(n => n.Project);
            e.HasMany(n => n.AccessControls);
            e.ToTable("todo_collections");
        });
        modelBuilder.Entity<TodoComment>(e => {
            e.HasOne(n => n.Todo);
            e.ToTable("todo_comments");
        });
        modelBuilder.Entity<TodoLabel>(e => {
            e.HasOne(n => n.Todo);
            e.ToTable("todo_labels");
        });
        modelBuilder.Entity<TodoCollectionAccessControl>(e => {
            e.HasOne(n => n.User);
            e.HasOne(n => n.Collection);
            e.ToTable("todo_collection_access_controls");
        });
        modelBuilder.Entity<ValidationEmail>(e => {
            e.ToTable("validation_emails");
        });

        base.OnModelCreating(modelBuilder);
    }
}
