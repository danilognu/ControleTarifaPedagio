using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class CriarTabelaArquivosImportados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArquivoImportadoId",
                table: "PassagensValePedagios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PessoaIdCad",
                table: "PassagensValePedagios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PessoaIdEmp",
                table: "PassagensValePedagios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArquivoImportadoId",
                table: "PassagensPedagios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PessoaIdCad",
                table: "PassagensPedagios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PessoaIdEmp",
                table: "PassagensPedagios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArquivoImportadoId",
                table: "Creditos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PessoaIdCad",
                table: "Creditos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PessoaIdEmp",
                table: "Creditos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArquivoImportadoId",
                table: "PassagensValePedagios");

            migrationBuilder.DropColumn(
                name: "PessoaIdCad",
                table: "PassagensValePedagios");

            migrationBuilder.DropColumn(
                name: "PessoaIdEmp",
                table: "PassagensValePedagios");

            migrationBuilder.DropColumn(
                name: "ArquivoImportadoId",
                table: "PassagensPedagios");

            migrationBuilder.DropColumn(
                name: "PessoaIdCad",
                table: "PassagensPedagios");

            migrationBuilder.DropColumn(
                name: "PessoaIdEmp",
                table: "PassagensPedagios");

            migrationBuilder.DropColumn(
                name: "ArquivoImportadoId",
                table: "Creditos");

            migrationBuilder.DropColumn(
                name: "PessoaIdCad",
                table: "Creditos");

            migrationBuilder.DropColumn(
                name: "PessoaIdEmp",
                table: "Creditos");
        }
    }
}
