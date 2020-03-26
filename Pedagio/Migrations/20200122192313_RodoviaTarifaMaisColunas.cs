using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class RodoviaTarifaMaisColunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "RodoviasTarifas",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Km",
                table: "RodoviasTarifas",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rodovia",
                table: "RodoviasTarifas",
                type: "varchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "RodoviasTarifas");

            migrationBuilder.DropColumn(
                name: "Km",
                table: "RodoviasTarifas");

            migrationBuilder.DropColumn(
                name: "Rodovia",
                table: "RodoviasTarifas");
        }
    }
}
