using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class RodoviaTarifa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rodovias",
                columns: table => new
                {
                    RodoviaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeRodovia = table.Column<string>(nullable: true),
                    DataCad = table.Column<DateTime>(nullable: false),
                    DataAlt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodovias", x => x.RodoviaId);
                });

            migrationBuilder.CreateTable(
                name: "RodoviasTarifas",
                columns: table => new
                {
                    RodoviaTarifaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RodoviaId = table.Column<int>(nullable: false),
                    AssociateCompKNownName = table.Column<string>(nullable: true),
                    Praca = table.Column<string>(nullable: true),
                    VehicleClassId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DateHourProgramStart = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodoviasTarifas", x => x.RodoviaTarifaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rodovias");

            migrationBuilder.DropTable(
                name: "RodoviasTarifas");
        }
    }
}
