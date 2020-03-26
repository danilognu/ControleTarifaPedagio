using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedagio.Migrations
{
    public partial class RodoviaTarifaOperadoras2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RodoviaTarifasOperadoras",
                columns: table => new
                {
                    RodoviaTarifasOperadorasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssociateId = table.Column<int>(nullable: false),
                    AssociateCompKnownName = table.Column<string>(nullable: true),
                    EntryId = table.Column<int>(nullable: false),
                    RoadCode = table.Column<string>(nullable: true),
                    RoadEntryKm = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    CategoryArtespId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Tarifa = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PAssagem90Dias = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodoviaTarifasOperadoras", x => x.RodoviaTarifasOperadorasId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RodoviaTarifasOperadoras");
        }
    }
}
