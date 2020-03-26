using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class CriarPassagensECreditos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Creditos",
                columns: table => new
                {
                    CreditoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Hora = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Viagem = table.Column<string>(nullable: true),
                    Praca = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    Embarcador = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditos", x => x.CreditoId);
                });

            migrationBuilder.CreateTable(
                name: "GetPassagensValePedagios",
                columns: table => new
                {
                    PassagemValePedagioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true),
                    Prefixo = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Categ = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Hora = table.Column<DateTime>(nullable: false),
                    Rodovia = table.Column<string>(nullable: true),
                    Praca = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    Viagem = table.Column<string>(nullable: true),
                    Embarcador = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetPassagensValePedagios", x => x.PassagemValePedagioId);
                });

            migrationBuilder.CreateTable(
                name: "PassagensPedagios",
                columns: table => new
                {
                    PassagemPedagioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true),
                    Prefixo = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Categ = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Hora = table.Column<DateTime>(nullable: false),
                    Rodovia = table.Column<string>(nullable: true),
                    Praca = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassagensPedagios", x => x.PassagemPedagioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Creditos");

            migrationBuilder.DropTable(
                name: "GetPassagensValePedagios");

            migrationBuilder.DropTable(
                name: "PassagensPedagios");
        }
    }
}
