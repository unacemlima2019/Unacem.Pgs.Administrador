using Microsoft.EntityFrameworkCore.Migrations;

namespace Unacem.Pgs.Cpra.Infraestructura.Datos.Migrations
{
    public partial class Actualiza_Progresol_Proveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FLAG_ACTIVO",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP");

            migrationBuilder.DropColumn(
                name: "FLAG_ACTUALIZA_SALDO_CUOTA",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP");

            migrationBuilder.RenameColumn(
                name: "FLAG_ACTIVO",
                schema: "dbo",
                table: "PGSTB_PROVEEDOR",
                newName: "DSC_FLAG_TIENDA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DSC_FLAG_TIENDA",
                schema: "dbo",
                table: "PGSTB_PROVEEDOR",
                newName: "FLAG_ACTIVO");

            migrationBuilder.AddColumn<string>(
                name: "FLAG_ACTIVO",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FLAG_ACTUALIZA_SALDO_CUOTA",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
