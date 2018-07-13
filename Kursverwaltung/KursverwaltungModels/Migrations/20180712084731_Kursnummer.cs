using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursverwaltung.Migrations
{
    public partial class Kursnummer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kursnummer",
                table: "Kurs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kursnummer",
                table: "Kurs");
        }
    }
}
