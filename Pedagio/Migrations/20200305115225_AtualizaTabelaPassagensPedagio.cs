using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class AtualizaTabelaPassagensPedagio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComparaTarifa",
                table: "PassagensPedagios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComparaTarifa",
                table: "PassagensPedagios");
        }
    }
}
