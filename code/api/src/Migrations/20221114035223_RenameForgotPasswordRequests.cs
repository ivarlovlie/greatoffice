using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOL.GreatOffice.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenameForgotPasswordRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_forgot_password_requests_users_user_id",
                table: "forgot_password_requests");

            migrationBuilder.DropPrimaryKey(
                name: "pk_forgot_password_requests",
                table: "forgot_password_requests");

            migrationBuilder.RenameTable(
                name: "forgot_password_requests",
                newName: "password_reset_requests");

            migrationBuilder.RenameIndex(
                name: "ix_forgot_password_requests_user_id",
                table: "password_reset_requests",
                newName: "ix_password_reset_requests_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_password_reset_requests",
                table: "password_reset_requests",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_password_reset_requests_users_user_id",
                table: "password_reset_requests",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_password_reset_requests_users_user_id",
                table: "password_reset_requests");

            migrationBuilder.DropPrimaryKey(
                name: "pk_password_reset_requests",
                table: "password_reset_requests");

            migrationBuilder.RenameTable(
                name: "password_reset_requests",
                newName: "forgot_password_requests");

            migrationBuilder.RenameIndex(
                name: "ix_password_reset_requests_user_id",
                table: "forgot_password_requests",
                newName: "ix_forgot_password_requests_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_forgot_password_requests",
                table: "forgot_password_requests",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_forgot_password_requests_users_user_id",
                table: "forgot_password_requests",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
