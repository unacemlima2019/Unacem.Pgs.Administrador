using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unacem.Pgs.Cpra.Infraestructura.Datos.Migrations
{
    public partial class Actualiza_Compras_Fechas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FCH_REGISTRO_COMPRA",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FCH_REGISTRO_COMPRA",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA");
        }
    }
}
