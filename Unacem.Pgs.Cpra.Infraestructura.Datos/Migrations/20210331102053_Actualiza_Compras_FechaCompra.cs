using Microsoft.EntityFrameworkCore.Migrations;

namespace Unacem.Pgs.Cpra.Infraestructura.Datos.Migrations
{
    public partial class Actualiza_Compras_FechaCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FCH_REGISTRO_COMPRA",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA",
                newName: "FCH_COMPRA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FCH_COMPRA",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA",
                newName: "FCH_REGISTRO_COMPRA");
        }
    }
}
