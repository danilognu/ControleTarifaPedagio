using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class RodoviaTarifaOperadoras3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "RodoviaTarifasOperadoras",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Km",
                table: "RodoviaTarifasOperadoras",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rodovia",
                table: "RodoviaTarifasOperadoras",
                type: "varchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "RodoviaTarifasOperadoras");

            migrationBuilder.DropColumn(
                name: "Km",
                table: "RodoviaTarifasOperadoras");

            migrationBuilder.DropColumn(
                name: "Rodovia",
                table: "RodoviaTarifasOperadoras");
        }
    }
}
