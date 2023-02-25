using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IOL.GreatOffice.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "time_categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    color = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_time_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "time_labels",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    color = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_time_labels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "time_entries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    stop = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_time_entries", x => x.id);
                    table.ForeignKey(
                        name: "fk_time_entries_time_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "time_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "forgot_password_requests",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_forgot_password_requests", x => x.id);
                    table.ForeignKey(
                        name: "fk_forgot_password_requests_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "time_entry_time_label",
                columns: table => new
                {
                    entries_id = table.Column<Guid>(type: "uuid", nullable: false),
                    labels_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_time_entry_time_label", x => new { x.entries_id, x.labels_id });
                    table.ForeignKey(
                        name: "fk_time_entry_time_label_time_entries_entries_id",
                        column: x => x.entries_id,
                        principalTable: "time_entries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_time_entry_time_label_time_labels_labels_id",
                        column: x => x.labels_id,
                        principalTable: "time_labels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created", "password", "username" },
                values: new object[] { new Guid("784938f0-cc0e-46ec-afa6-fc60b47b28db"), new DateTime(2021, 5, 17, 20, 21, 14, 827, DateTimeKind.Utc).AddTicks(4868), "AAAAAAEAACcQAAAAEJdtrX3pEeIbcgY+BDAr56gvfbc420ag1TllA0cK6Q6Gw3+gGDIQtYIZnisW3dmqaQ==", "admin@ivarlovlie.no" });

            migrationBuilder.CreateIndex(
                name: "ix_forgot_password_requests_user_id",
                table: "forgot_password_requests",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_entries_category_id",
                table: "time_entries",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_entry_time_label_labels_id",
                table: "time_entry_time_label",
                column: "labels_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "forgot_password_requests");

            migrationBuilder.DropTable(
                name: "time_entry_time_label");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "time_entries");

            migrationBuilder.DropTable(
                name: "time_labels");

            migrationBuilder.DropTable(
                name: "time_categories");
        }
    }
}
