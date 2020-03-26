using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class UpdateTablePassagensValePedagio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EixoAbaixado",
                table: "PassagensValePedagios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EixoSuspenso",
                table: "PassagensValePedagios",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EixoAbaixado",
                table: "PassagensValePedagios");

            migrationBuilder.DropColumn(
                name: "EixoSuspenso",
                table: "PassagensValePedagios");
        }
    }
}
