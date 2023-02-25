using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOL.GreatOffice.Api.Migrations
{
    /// <inheritdoc />
    public partial class ValidationEmailQueue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "email_last_validated",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "validation_emails",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    emailsentat = table.Column<DateTime>(name: "email_sent_at", type: "timestamp with time zone", nullable: false),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_validation_emails", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "validation_emails");

            migrationBuilder.DropColumn(
                name: "email_last_validated",
                table: "users");
        }
    }
}
