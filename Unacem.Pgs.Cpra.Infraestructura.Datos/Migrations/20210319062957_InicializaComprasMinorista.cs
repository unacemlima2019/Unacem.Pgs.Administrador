using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unacem.Pgs.Cpra.Infraestructura.Datos.Migrations
{
    public partial class InicializaComprasMinorista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "PGSTB_CATEGORIA_MATERIAL",
            //    columns: table => new
            //    {
            //        COD_CATEGORIA_MATERIAL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        COD_CATEGORIA_SAP = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: true),
            //        DSC_NOMBRE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        DSC_IMAGEN = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
            //        FLAG_ACTIVO = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CATEGORIA_MATERIAL", x => x.COD_CATEGORIA_MATERIAL);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
            //    columns: table => new
            //    {
            //        COD_CLIENTEPS_SAP = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        COD_PADRE = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
            //        COD_HIJO = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
            //        DSC_LONGITUD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        DSC_LATITUD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        DSC_NOMBRE_COMERCIAL = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
            //        DSC_CELULAR_DUENO = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
            //        DSC_DIRECCION = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
            //        COD_PDV = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
            //        DSC_FLAG_TIENDA = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
            //        DSC_LOGO_TIENDA = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
            //        DSC_HORARIO_ATENCION = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        DSC_PROVINCIA = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            //        DSC_DISTRITO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            //        DSC_DEPARTAMENTO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            //        DSC_TIPO_PROGRESOL = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
            //        DSC_RAZON_SOCIAL = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PGSTB_TEMP_FUN_CLIENTESPS_SAP", x => x.COD_CLIENTEPS_SAP);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PGSTB_MATERIAL",
            //    columns: table => new
            //    {
            //        COD_MATERIAL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        COD_PRODUCTO_SAP = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
            //        COD_SKU = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
            //        DSC_NOMBRE = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
            //        DSC_PRODUCTO_PARSER = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
            //        DSC_IMAGEN = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
            //        DSC_USUARIO_CREACION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        FCH_REGISTRO = table.Column<DateTime>(type: "datetime", nullable: false),
            //        DSC_USUARIO_UPD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        FCH_UPD = table.Column<DateTime>(type: "datetime", nullable: false),
            //        NUM_ORD_MATERIALCEMENTO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        FLAG_ACTIVO = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
            //        COD_CATEGORIA_MATERIAL = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MATERIAL", x => x.COD_MATERIAL);
            //        table.ForeignKey(
            //            name: "FK_PGSTB_MATERIAL_PGSTB_CATEGORIA_MATERIAL",
            //            column: x => x.COD_CATEGORIA_MATERIAL,
            //            principalTable: "PGSTB_CATEGORIA_MATERIAL",
            //            principalColumn: "COD_CATEGORIA_MATERIAL",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_PGSTB_MATERIAL_COD_CATEGORIA_MATERIAL",
            //    table: "PGSTB_MATERIAL",
            //    column: "COD_CATEGORIA_MATERIAL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PGSTB_MATERIAL_COD_SKU",
            //    table: "PGSTB_MATERIAL",
            //    column: "COD_SKU",
            //    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PGSTB_MATERIAL");

            migrationBuilder.DropTable(
                name: "PGSTB_TEMP_FUN_CLIENTESPS_SAP");

            migrationBuilder.DropTable(
                name: "PGSTB_CATEGORIA_MATERIAL");
        }
    }
}
