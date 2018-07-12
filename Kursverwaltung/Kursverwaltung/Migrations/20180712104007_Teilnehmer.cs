using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursverwaltung.Migrations
{
    public partial class Teilnehmer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teilnehmer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teilnehmer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeilnehmerTermin",
                columns: table => new
                {
                    TeilnehmerId = table.Column<int>(nullable: false),
                    TerminId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeilnehmerTermin", x => new { x.TeilnehmerId, x.TerminId });
                    table.ForeignKey(
                        name: "FK_TeilnehmerTermin_Teilnehmer_TeilnehmerId",
                        column: x => x.TeilnehmerId,
                        principalTable: "Teilnehmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeilnehmerTermin_Termin_TerminId",
                        column: x => x.TerminId,
                        principalTable: "Termin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeilnehmerTermin_TerminId",
                table: "TeilnehmerTermin",
                column: "TerminId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeilnehmerTermin");

            migrationBuilder.DropTable(
                name: "Teilnehmer");
        }
    }
}
