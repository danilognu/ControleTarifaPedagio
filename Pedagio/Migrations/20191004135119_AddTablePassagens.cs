using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class AddTablePassagens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passagens",
                columns: table => new
                {
                    PassagemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Hora = table.Column<string>(nullable: true),
                    Rodovia = table.Column<string>(nullable: true),
                    Praca = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    Viagem = table.Column<int>(nullable: false),
                    Embarcado = table.Column<string>(nullable: true),
                    Categoria = table.Column<string>(nullable: true),
                    Tag = table.Column<int>(nullable: false),
                    NumVP = table.Column<int>(nullable: false),
                    DataCad = table.Column<DateTime>(nullable: false),
                    DataAlt = table.Column<DateTime>(nullable: false),
                    PessoaIdCad = table.Column<int>(nullable: false),
                    PessoaIdAlt = table.Column<int>(nullable: false),
                    PessoaIdEmp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagens", x => x.PassagemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passagens");
        }
    }
}
