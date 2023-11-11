using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOL.GreatOffice.Api.Migrations
{
    public partial class Tenants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                table: "time_labels",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "deleted_by_id",
                table: "time_labels",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "modified_by_id",
                table: "time_labels",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                table: "time_labels",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                table: "time_entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "deleted_by_id",
                table: "time_entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "modified_by_id",
                table: "time_entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                table: "time_entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_id",
                table: "time_categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "deleted_by_id",
                table: "time_categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "modified_by_id",
                table: "time_categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                table: "time_categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "tenants",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    contact_email = table.Column<string>(type: "text", nullable: true),
                    master_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    master_user_password = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id1 = table.Column<Guid>(type: "uuid", nullable: true),
                    modified_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_by_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenants", x => x.id);
                    table.ForeignKey(
                        name: "fk_tenants_tenants_tenant_id1",
                        column: x => x.tenant_id1,
                        principalTable: "tenants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_tenants_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tenants_users_deleted_by_id",
                        column: x => x.deleted_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tenants_users_modified_by_id",
                        column: x => x.modified_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tenants_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_time_labels_created_by_id",
                table: "time_labels",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_labels_deleted_by_id",
                table: "time_labels",
                column: "deleted_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_labels_modified_by_id",
                table: "time_labels",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_labels_tenant_id",
                table: "time_labels",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_entries_created_by_id",
                table: "time_entries",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_entries_deleted_by_id",
                table: "time_entries",
                column: "deleted_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_entries_modified_by_id",
                table: "time_entries",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_entries_tenant_id",
                table: "time_entries",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_categories_created_by_id",
                table: "time_categories",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_categories_deleted_by_id",
                table: "time_categories",
                column: "deleted_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_categories_modified_by_id",
                table: "time_categories",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_categories_tenant_id",
                table: "time_categories",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenants_created_by_id",
                table: "tenants",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenants_deleted_by_id",
                table: "tenants",
                column: "deleted_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenants_modified_by_id",
                table: "tenants",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenants_tenant_id1",
                table: "tenants",
                column: "tenant_id1");

            migrationBuilder.CreateIndex(
                name: "ix_tenants_user_id",
                table: "tenants",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_categories_tenants_tenant_id",
                table: "time_categories",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_categories_users_created_by_id",
                table: "time_categories",
                column: "created_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_categories_users_deleted_by_id",
                table: "time_categories",
                column: "deleted_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_categories_users_modified_by_id",
                table: "time_categories",
                column: "modified_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_entries_tenants_tenant_id",
                table: "time_entries",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_entries_users_created_by_id",
                table: "time_entries",
                column: "created_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_entries_users_deleted_by_id",
                table: "time_entries",
                column: "deleted_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_entries_users_modified_by_id",
                table: "time_entries",
                column: "modified_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_labels_tenants_tenant_id",
                table: "time_labels",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_labels_users_created_by_id",
                table: "time_labels",
                column: "created_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_labels_users_deleted_by_id",
                table: "time_labels",
                column: "deleted_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_labels_users_modified_by_id",
                table: "time_labels",
                column: "modified_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_time_categories_tenants_tenant_id",
                table: "time_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_time_categories_users_created_by_id",
                table: "time_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_time_categories_users_deleted_by_id",
                table: "time_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_time_categories_users_modified_by_id",
                table: "time_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_time_entries_tenants_tenant_id",
                table: "time_entries");

            migrationBuilder.DropForeignKey(
                name: "fk_time_entries_users_created_by_id",
                table: "time_entries");

            migrationBuilder.DropForeignKey(
                name: "fk_time_entries_users_deleted_by_id",
                table: "time_entries");

            migrationBuilder.DropForeignKey(
                name: "fk_time_entries_users_modified_by_id",
                table: "time_entries");

            migrationBuilder.DropForeignKey(
                name: "fk_time_labels_tenants_tenant_id",
                table: "time_labels");

            migrationBuilder.DropForeignKey(
                name: "fk_time_labels_users_created_by_id",
                table: "time_labels");

            migrationBuilder.DropForeignKey(
                name: "fk_time_labels_users_deleted_by_id",
                table: "time_labels");

            migrationBuilder.DropForeignKey(
                name: "fk_time_labels_users_modified_by_id",
                table: "time_labels");

            migrationBuilder.DropTable(
                name: "tenants");

            migrationBuilder.DropIndex(
                name: "ix_time_labels_created_by_id",
                table: "time_labels");

            migrationBuilder.DropIndex(
                name: "ix_time_labels_deleted_by_id",
                table: "time_labels");

            migrationBuilder.DropIndex(
                name: "ix_time_labels_modified_by_id",
                table: "time_labels");

            migrationBuilder.DropIndex(
                name: "ix_time_labels_tenant_id",
                table: "time_labels");

            migrationBuilder.DropIndex(
                name: "ix_time_entries_created_by_id",
                table: "time_entries");

            migrationBuilder.DropIndex(
                name: "ix_time_entries_deleted_by_id",
                table: "time_entries");

            migrationBuilder.DropIndex(
                name: "ix_time_entries_modified_by_id",
                table: "time_entries");

            migrationBuilder.DropIndex(
                name: "ix_time_entries_tenant_id",
                table: "time_entries");

            migrationBuilder.DropIndex(
                name: "ix_time_categories_created_by_id",
                table: "time_categories");

            migrationBuilder.DropIndex(
                name: "ix_time_categories_deleted_by_id",
                table: "time_categories");

            migrationBuilder.DropIndex(
                name: "ix_time_categories_modified_by_id",
                table: "time_categories");

            migrationBuilder.DropIndex(
                name: "ix_time_categories_tenant_id",
                table: "time_categories");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                table: "time_labels");

            migrationBuilder.DropColumn(
                name: "deleted_by_id",
                table: "time_labels");

            migrationBuilder.DropColumn(
                name: "modified_by_id",
                table: "time_labels");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                table: "time_labels");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                table: "time_entries");

            migrationBuilder.DropColumn(
                name: "deleted_by_id",
                table: "time_entries");

            migrationBuilder.DropColumn(
                name: "modified_by_id",
                table: "time_entries");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                table: "time_entries");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                table: "time_categories");

            migrationBuilder.DropColumn(
                name: "deleted_by_id",
                table: "time_categories");

            migrationBuilder.DropColumn(
                name: "modified_by_id",
                table: "time_categories");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                table: "time_categories");
        }
    }
}
