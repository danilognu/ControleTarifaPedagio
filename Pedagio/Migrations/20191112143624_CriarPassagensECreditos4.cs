using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class CriarPassagensECreditos4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GetPassagensValePedagios",
                table: "GetPassagensValePedagios");

            migrationBuilder.RenameTable(
                name: "GetPassagensValePedagios",
                newName: "PassagensValePedagios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassagensValePedagios",
                table: "PassagensValePedagios",
                column: "PassagemValePedagioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PassagensValePedagios",
                table: "PassagensValePedagios");

            migrationBuilder.RenameTable(
                name: "PassagensValePedagios",
                newName: "GetPassagensValePedagios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetPassagensValePedagios",
                table: "GetPassagensValePedagios",
                column: "PassagemValePedagioId");
        }
    }
}
