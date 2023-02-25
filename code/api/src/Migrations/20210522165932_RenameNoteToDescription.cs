using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IOL.GreatOffice.Api.Migrations
{
    public partial class RenameNoteToDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("784938f0-cc0e-46ec-afa6-fc60b47b28db"));

            migrationBuilder.RenameColumn(
                name: "note",
                table: "time_entries",
                newName: "description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "time_entries",
                newName: "note");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created", "password", "username" },
                values: new object[] { new Guid("784938f0-cc0e-46ec-afa6-fc60b47b28db"), new DateTime(2021, 5, 17, 20, 21, 14, 827, DateTimeKind.Utc).AddTicks(4868), "AAAAAAEAACcQAAAAEJdtrX3pEeIbcgY+BDAr56gvfbc420ag1TllA0cK6Q6Gw3+gGDIQtYIZnisW3dmqaQ==", "admin@ivarlovlie.no" });
        }
    }
}
