using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class TabelaVeiculoCategoriaVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdEixoAbaixado",
                table: "Veiculos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdEixoSuspenso",
                table: "Veiculos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaIdEixoAbaixado",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "CategoriaIdEixoSuspenso",
                table: "Veiculos");
        }
    }
}
