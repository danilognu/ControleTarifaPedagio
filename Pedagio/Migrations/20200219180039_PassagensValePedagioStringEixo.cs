using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class PassagensValePedagioStringEixo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EixoAbaixadoComparacao",
                table: "PassagensValePedagios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EixoSuspensoComparacao",
                table: "PassagensValePedagios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EixoAbaixadoComparacao",
                table: "PassagensValePedagios");

            migrationBuilder.DropColumn(
                name: "EixoSuspensoComparacao",
                table: "PassagensValePedagios");
        }
    }
}
