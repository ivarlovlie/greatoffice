using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOL.GreatOffice.Api.Migrations
{
    public partial class RemoveUnusedNavs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "time_entry_time_label");

            migrationBuilder.AddColumn<Guid>(
                name: "time_entry_id",
                table: "time_labels",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_time_labels_time_entry_id",
                table: "time_labels",
                column: "time_entry_id");

            migrationBuilder.AddForeignKey(
                name: "fk_time_labels_time_entries_time_entry_id",
                table: "time_labels",
                column: "time_entry_id",
                principalTable: "time_entries",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_time_labels_time_entries_time_entry_id",
                table: "time_labels");

            migrationBuilder.DropIndex(
                name: "ix_time_labels_time_entry_id",
                table: "time_labels");

            migrationBuilder.DropColumn(
                name: "time_entry_id",
                table: "time_labels");

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

            migrationBuilder.CreateIndex(
                name: "ix_time_entry_time_label_labels_id",
                table: "time_entry_time_label",
                column: "labels_id");
        }
    }
}
