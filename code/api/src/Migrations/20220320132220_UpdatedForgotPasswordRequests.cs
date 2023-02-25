using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOL.GreatOffice.Api.Migrations
{
    public partial class UpdatedForgotPasswordRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_forgot_password_requests_users_user_id",
                table: "forgot_password_requests");

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "forgot_password_requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_forgot_password_requests_users_user_id",
                table: "forgot_password_requests",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_forgot_password_requests_users_user_id",
                table: "forgot_password_requests");

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "forgot_password_requests",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "fk_forgot_password_requests_users_user_id",
                table: "forgot_password_requests",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
