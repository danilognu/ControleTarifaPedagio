using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class AdicionaColunaPassagensPegadio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EixoAbaixadoComparacao",
                table: "PassagensPedagios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EixoSuspensoComparacao",
                table: "PassagensPedagios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EixoAbaixadoComparacao",
                table: "PassagensPedagios");

            migrationBuilder.DropColumn(
                name: "EixoSuspensoComparacao",
                table: "PassagensPedagios");
        }
    }
}
