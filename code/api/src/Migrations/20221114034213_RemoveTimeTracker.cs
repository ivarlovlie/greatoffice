using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOL.GreatOffice.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTimeTracker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "time_labels");

            migrationBuilder.DropTable(
                name: "time_entries");

            migrationBuilder.DropTable(
                name: "time_categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "time_categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantid = table.Column<Guid>(name: "tenant_id", type: "uuid", nullable: true),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: true),
                    color = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    createdby = table.Column<Guid>(name: "created_by", type: "uuid", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "timestamp with time zone", nullable: true),
                    deletedby = table.Column<Guid>(name: "deleted_by", type: "uuid", nullable: true),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<Guid>(name: "modified_by", type: "uuid", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_time_categories", x => x.id);
                    table.ForeignKey(
                        name: "fk_time_categories_tenants_tenant_id",
                        column: x => x.tenantid,
                        principalTable: "tenants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_time_categories_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "time_entries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    categoryid = table.Column<Guid>(name: "category_id", type: "uuid", nullable: true),
                    tenantid = table.Column<Guid>(name: "tenant_id", type: "uuid", nullable: true),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    createdby = table.Column<Guid>(name: "created_by", type: "uuid", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "timestamp with time zone", nullable: true),
                    deletedby = table.Column<Guid>(name: "deleted_by", type: "uuid", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<Guid>(name: "modified_by", type: "uuid", nullable: true),
                    start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    stop = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_time_entries", x => x.id);
                    table.ForeignKey(
                        name: "fk_time_entries_tenants_tenant_id",
                        column: x => x.tenantid,
                        principalTable: "tenants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_time_entries_time_categories_category_id",
                        column: x => x.categoryid,
                        principalTable: "time_categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_time_entries_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "time_labels",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantid = table.Column<Guid>(name: "tenant_id", type: "uuid", nullable: true),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: true),
                    color = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    createdby = table.Column<Guid>(name: "created_by", type: "uuid", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "timestamp with time zone", nullable: true),
                    deletedby = table.Column<Guid>(name: "deleted_by", type: "uuid", nullable: true),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<Guid>(name: "modified_by", type: "uuid", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    timeentryid = table.Column<Guid>(name: "time_entry_id", type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_time_labels", x => x.id);
                    table.ForeignKey(
                        name: "fk_time_labels_tenants_tenant_id",
                        column: x => x.tenantid,
                        principalTable: "tenants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_time_labels_time_entries_time_entry_id",
                        column: x => x.timeentryid,
                        principalTable: "time_entries",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_time_labels_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_time_categories_tenant_id",
                table: "time_categories",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_categories_user_id",
                table: "time_categories",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_entries_category_id",
                table: "time_entries",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_entries_tenant_id",
                table: "time_entries",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_entries_user_id",
                table: "time_entries",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_labels_tenant_id",
                table: "time_labels",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_labels_time_entry_id",
                table: "time_labels",
                column: "time_entry_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_labels_user_id",
                table: "time_labels",
                column: "user_id");
        }
    }
}
