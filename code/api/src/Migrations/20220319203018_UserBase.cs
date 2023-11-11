using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOL.GreatOffice.Api.Migrations
{
    public partial class UserBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "modified_at",
                table: "forgot_password_requests");

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "time_labels",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "time_entries",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "time_categories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "ix_time_labels_user_id",
                table: "time_labels",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_entries_user_id",
                table: "time_entries",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_time_categories_user_id",
                table: "time_categories",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_categories_users_user_id",
                table: "time_categories",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_entries_users_user_id",
                table: "time_entries",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_labels_users_user_id",
                table: "time_labels",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_time_categories_users_user_id",
                table: "time_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_time_entries_users_user_id",
                table: "time_entries");

            migrationBuilder.DropForeignKey(
                name: "fk_time_labels_users_user_id",
                table: "time_labels");

            migrationBuilder.DropIndex(
                name: "ix_time_labels_user_id",
                table: "time_labels");

            migrationBuilder.DropIndex(
                name: "ix_time_entries_user_id",
                table: "time_entries");

            migrationBuilder.DropIndex(
                name: "ix_time_categories_user_id",
                table: "time_categories");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "modified_at",
                table: "forgot_password_requests",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
