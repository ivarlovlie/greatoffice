using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOL.GreatOffice.Api.Migrations
{
    public partial class RenameCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "created",
                table: "users",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "time_labels",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "time_entries",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "time_categories",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "forgot_password_requests",
                newName: "created_at");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "users",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "time_labels",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "time_entries",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "time_categories",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "forgot_password_requests",
                newName: "created");
        }
    }
}
