using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOL.GreatOffice.Api.Migrations
{
    public partial class MinorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_project_member_projects_project_id",
                table: "project_member");

            migrationBuilder.DropForeignKey(
                name: "fk_project_member_users_user_id",
                table: "project_member");

            migrationBuilder.DropPrimaryKey(
                name: "pk_project_member",
                table: "project_member");

            migrationBuilder.RenameTable(
                name: "project_member",
                newName: "project_members");

            migrationBuilder.RenameIndex(
                name: "ix_project_member_user_id",
                table: "project_members",
                newName: "ix_project_members_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_project_member_project_id",
                table: "project_members",
                newName: "ix_project_members_project_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_project_members",
                table: "project_members",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_project_members_projects_project_id",
                table: "project_members",
                column: "project_id",
                principalTable: "projects",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_project_members_users_user_id",
                table: "project_members",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_project_members_projects_project_id",
                table: "project_members");

            migrationBuilder.DropForeignKey(
                name: "fk_project_members_users_user_id",
                table: "project_members");

            migrationBuilder.DropPrimaryKey(
                name: "pk_project_members",
                table: "project_members");

            migrationBuilder.RenameTable(
                name: "project_members",
                newName: "project_member");

            migrationBuilder.RenameIndex(
                name: "ix_project_members_user_id",
                table: "project_member",
                newName: "ix_project_member_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_project_members_project_id",
                table: "project_member",
                newName: "ix_project_member_project_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_project_member",
                table: "project_member",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_project_member_projects_project_id",
                table: "project_member",
                column: "project_id",
                principalTable: "projects",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_project_member_users_user_id",
                table: "project_member",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
