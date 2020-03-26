using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class UpdateTabelaPassagensPedagio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CidadeChave",
                table: "PassagensPedagios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstadoChave",
                table: "PassagensPedagios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KmChave",
                table: "PassagensPedagios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpRodoviaChave",
                table: "PassagensPedagios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SentidoChave",
                table: "PassagensPedagios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CidadeChave",
                table: "PassagensPedagios");

            migrationBuilder.DropColumn(
                name: "EstadoChave",
                table: "PassagensPedagios");

            migrationBuilder.DropColumn(
                name: "KmChave",
                table: "PassagensPedagios");

            migrationBuilder.DropColumn(
                name: "OpRodoviaChave",
                table: "PassagensPedagios");

            migrationBuilder.DropColumn(
                name: "SentidoChave",
                table: "PassagensPedagios");
        }
    }
}
