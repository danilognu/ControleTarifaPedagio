using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class CriartabelaDesvio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContabilizaDesvio",
                columns: table => new
                {
                    ContabilizaDesvioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(nullable: true),
                    Viagem = table.Column<string>(nullable: true),
                    ValorCredito = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ValorPassagemValePedagio = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Desvio = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ArquivoImportadoId = table.Column<int>(nullable: false),
                    DataCad = table.Column<DateTime>(nullable: false),
                    PessoaIdCad = table.Column<int>(nullable: false),
                    PessoaIdEmp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContabilizaDesvio", x => x.ContabilizaDesvioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContabilizaDesvio");
        }
    }
}
