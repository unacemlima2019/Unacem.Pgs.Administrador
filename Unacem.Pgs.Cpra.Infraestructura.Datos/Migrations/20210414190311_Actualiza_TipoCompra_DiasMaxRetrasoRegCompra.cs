using Microsoft.EntityFrameworkCore.Migrations;

namespace Unacem.Pgs.Cpra.Infraestructura.Datos.Migrations
{
    public partial class Actualiza_TipoCompra_DiasMaxRetrasoRegCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NUM_DIAS_RETRASO_REGISTRO",
                schema: "dbo",
                table: "PGSTB_TIPO_COMPRA",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NUM_DIAS_RETRASO_REGISTRO",
                schema: "dbo",
                table: "PGSTB_TIPO_COMPRA");
        }
    }
}
