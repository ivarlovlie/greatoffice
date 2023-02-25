using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOL.GreatOffice.Api.Migrations
{
    public partial class FleshOutNewModules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tenants_tenants_tenant_id1",
                table: "tenants");

            migrationBuilder.DropForeignKey(
                name: "fk_tenants_users_created_by_id",
                table: "tenants");

            migrationBuilder.DropForeignKey(
                name: "fk_tenants_users_deleted_by_id",
                table: "tenants");

            migrationBuilder.DropForeignKey(
                name: "fk_tenants_users_modified_by_id",
                table: "tenants");

            migrationBuilder.DropForeignKey(
                name: "fk_tenants_users_user_id",
                table: "tenants");

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
                name: "fk_time_categories_users_user_id",
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
                name: "fk_time_entries_users_user_id",
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

            migrationBuilder.DropForeignKey(
                name: "fk_time_labels_users_user_id",
                table: "time_labels");

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
                name: "ix_time_labels_user_id",
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
                name: "ix_time_entries_user_id",
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

            migrationBuilder.DropIndex(
                name: "ix_time_categories_user_id",
                table: "time_categories");

            migrationBuilder.DropIndex(
                name: "ix_tenants_created_by_id",
                table: "tenants");

            migrationBuilder.DropIndex(
                name: "ix_tenants_deleted_by_id",
                table: "tenants");

            migrationBuilder.DropIndex(
                name: "ix_tenants_modified_by_id",
                table: "tenants");

            migrationBuilder.DropIndex(
                name: "ix_tenants_tenant_id1",
                table: "tenants");

            migrationBuilder.DropIndex(
                name: "ix_tenants_user_id",
                table: "tenants");

            migrationBuilder.DropColumn(
                name: "tenant_id1",
                table: "tenants");

            migrationBuilder.AddColumn<bool>(
                name: "deleted",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "time_labels",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<bool>(
                name: "deleted",
                table: "time_labels",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "time_entries",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<bool>(
                name: "deleted",
                table: "time_entries",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "time_categories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<bool>(
                name: "deleted",
                table: "time_categories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "tenants",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<bool>(
                name: "deleted",
                table: "tenants",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "deleted",
                table: "api_access_tokens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "tenant_user",
                columns: table => new
                {
                    tenants_id = table.Column<Guid>(type: "uuid", nullable: false),
                    users_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant_user", x => new { x.tenants_id, x.users_id });
                    table.ForeignKey(
                        name: "fk_tenant_user_tenants_tenants_id",
                        column: x => x.tenants_id,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tenant_user_users_users_id",
                        column: x => x.users_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_tenant_user_users_id",
                table: "tenant_user",
                column: "users_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tenant_user");

            migrationBuilder.DropColumn(
                name: "deleted",
                table: "users");

            migrationBuilder.DropColumn(
                name: "email",
                table: "users");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "users");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "users");

            migrationBuilder.DropColumn(
                name: "deleted",
                table: "time_labels");

            migrationBuilder.DropColumn(
                name: "deleted",
                table: "time_entries");

            migrationBuilder.DropColumn(
                name: "deleted",
                table: "time_categories");

            migrationBuilder.DropColumn(
                name: "deleted",
                table: "tenants");

            migrationBuilder.DropColumn(
                name: "deleted",
                table: "api_access_tokens");

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "time_labels",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "time_entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "time_categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "tenants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id1",
                table: "tenants",
                type: "uuid",
                nullable: true);

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
                name: "ix_time_labels_user_id",
                table: "time_labels",
                column: "user_id");

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
                name: "ix_time_entries_user_id",
                table: "time_entries",
                column: "user_id");

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
                name: "ix_time_categories_user_id",
                table: "time_categories",
                column: "user_id");

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
                name: "fk_tenants_tenants_tenant_id1",
                table: "tenants",
                column: "tenant_id1",
                principalTable: "tenants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_tenants_users_created_by_id",
                table: "tenants",
                column: "created_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_tenants_users_deleted_by_id",
                table: "tenants",
                column: "deleted_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_tenants_users_modified_by_id",
                table: "tenants",
                column: "modified_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_tenants_users_user_id",
                table: "tenants",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_categories_tenants_tenant_id",
                table: "time_categories",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_categories_users_created_by_id",
                table: "time_categories",
                column: "created_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_categories_users_deleted_by_id",
                table: "time_categories",
                column: "deleted_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_categories_users_modified_by_id",
                table: "time_categories",
                column: "modified_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_categories_users_user_id",
                table: "time_categories",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_entries_tenants_tenant_id",
                table: "time_entries",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_entries_users_created_by_id",
                table: "time_entries",
                column: "created_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_entries_users_deleted_by_id",
                table: "time_entries",
                column: "deleted_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_entries_users_modified_by_id",
                table: "time_entries",
                column: "modified_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_entries_users_user_id",
                table: "time_entries",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_time_labels_tenants_tenant_id",
                table: "time_labels",
                column: "tenant_id",
                principalTable: "tenants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_labels_users_created_by_id",
                table: "time_labels",
                column: "created_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_labels_users_deleted_by_id",
                table: "time_labels",
                column: "deleted_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_labels_users_modified_by_id",
                table: "time_labels",
                column: "modified_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_labels_users_user_id",
                table: "time_labels",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
