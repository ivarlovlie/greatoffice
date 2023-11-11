using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOL.GreatOffice.Api.Migrations
{
    public partial class MoreMinorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_customers_projects_project_id",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "ix_customers_project_id",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "project_id",
                table: "customers");

            migrationBuilder.CreateTable(
                name: "customer_project",
                columns: table => new
                {
                    customers_id = table.Column<Guid>(type: "uuid", nullable: false),
                    projects_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer_project", x => new { x.customers_id, x.projects_id });
                    table.ForeignKey(
                        name: "fk_customer_project_customers_customers_id",
                        column: x => x.customers_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_customer_project_projects_projects_id",
                        column: x => x.projects_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_customer_project_projects_id",
                table: "customer_project",
                column: "projects_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer_project");

            migrationBuilder.AddColumn<Guid>(
                name: "project_id",
                table: "customers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_customers_project_id",
                table: "customers",
                column: "project_id");

            migrationBuilder.AddForeignKey(
                name: "fk_customers_projects_project_id",
                table: "customers",
                column: "project_id",
                principalTable: "projects",
                principalColumn: "id");
        }
    }
}
