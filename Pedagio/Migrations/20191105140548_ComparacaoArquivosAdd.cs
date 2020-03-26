using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class ComparacaoArquivosAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComparacaoArquivos",
                columns: table => new
                {
                    ComparacaoArquivosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeArqOrigem1 = table.Column<string>(nullable: true),
                    NomeArqGerado1 = table.Column<string>(nullable: true),
                    NomeArqOrigem2 = table.Column<string>(nullable: true),
                    NomeArqGerado2 = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    PessoaIdCad = table.Column<int>(nullable: false),
                    PessoaIdEmp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComparacaoArquivos", x => x.ComparacaoArquivosId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComparacaoArquivos");
        }
    }
}
