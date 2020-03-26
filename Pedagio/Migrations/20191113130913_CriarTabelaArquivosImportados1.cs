using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class CriarTabelaArquivosImportados1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArquivosImportados",
                columns: table => new
                {
                    ArquivoImportadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeOrigem = table.Column<string>(nullable: true),
                    NomeGerado = table.Column<string>(nullable: true),
                    PastaImportacao = table.Column<string>(nullable: true),
                    DataImportacao = table.Column<DateTime>(nullable: false),
                    PessoaIdCad = table.Column<int>(nullable: false),
                    PessoaIdEmp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArquivosImportados", x => x.ArquivoImportadoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArquivosImportados");
        }
    }
}
