using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOL.GreatOffice.Api.Migrations
{
    public partial class NullableOptionalBaseFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<Guid>(
                name: "tenant_id",
                table: "time_labels",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "modified_by_id",
                table: "time_labels",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "deleted_by_id",
                table: "time_labels",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "time_labels",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "tenant_id",
                table: "time_entries",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "modified_by_id",
                table: "time_entries",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "deleted_by_id",
                table: "time_entries",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "time_entries",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "tenant_id",
                table: "time_categories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "modified_by_id",
                table: "time_categories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "deleted_by_id",
                table: "time_categories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "time_categories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "tenant_id",
                table: "tenants",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "modified_by_id",
                table: "tenants",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "deleted_by_id",
                table: "tenants",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "tenants",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<Guid>(
                name: "tenant_id",
                table: "time_labels",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "modified_by_id",
                table: "time_labels",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "deleted_by_id",
                table: "time_labels",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "time_labels",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "tenant_id",
                table: "time_entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "modified_by_id",
                table: "time_entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "deleted_by_id",
                table: "time_entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "time_entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "tenant_id",
                table: "time_categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "modified_by_id",
                table: "time_categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "deleted_by_id",
                table: "time_categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "time_categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "tenant_id",
                table: "tenants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "modified_by_id",
                table: "tenants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "deleted_by_id",
                table: "tenants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "tenants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_tenants_users_created_by_id",
                table: "tenants",
                column: "created_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tenants_users_deleted_by_id",
                table: "tenants",
                column: "deleted_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tenants_users_modified_by_id",
                table: "tenants",
                column: "modified_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
