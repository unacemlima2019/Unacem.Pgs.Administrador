using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unacem.Pgs.Cpra.Infraestructura.Datos.Migrations
{
    public partial class CreacionRoot_ComprasMinoristaYCuotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                newName: "COD_PROGRESOL");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_TEMP_FUN_CLIENTESPS_SAP",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                column: "COD_PROGRESOL");

            migrationBuilder.CreateTable(
                name: "PGSTB_CUOTA_LOCAL",
                schema: "dbo",
                columns: table => new
                {
                    COD_CUOTA_LOCAL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_LOCAL_PROGRESOL_SAP = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: true),
                    DSC_PERIODO = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    MNT_LIMITE_CUOTA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MNT_CUOTA_COMPLETADA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FLAG_ACTIVO = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    COD_PROGRESOL = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUOTA_LOCAL", x => x.COD_CUOTA_LOCAL);
                    table.ForeignKey(
                        name: "FK_PGSTB_CUOTA_LOCAL_PGSTB_PROGRESOL",
                        column: x => x.COD_PROGRESOL,
                        principalTable: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                        principalColumn: "COD_PROGRESOL");
                });

            migrationBuilder.CreateTable(
                name: "PGSTB_TIPO_COMPRA",
                schema: "dbo",
                columns: table => new
                {
                    COD_TIPO_COMPRA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DSC_TIPO_COMPRA = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    FLAG_ACTIVO = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_COMPRA", x => x.COD_TIPO_COMPRA);
                });

            migrationBuilder.CreateTable(
                name: "PGSTB_TIPO_PROVEEDOR",
                schema: "dbo",
                columns: table => new
                {
                    COD_TIPO_PROVEEDOR = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DSC_TIPO_PROVEEDOR = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: true),
                    DSC_ABREV_TIPO_PROVEEDOR = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FLAG_ACTIVO = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_PROVEEDOR", x => x.COD_TIPO_PROVEEDOR);
                });

            migrationBuilder.CreateTable(
                name: "PGSTB_CUOTA_LOCAL_DET",
                schema: "dbo",
                columns: table => new
                {
                    COD_CUOTA_LOCAL_DET = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MNT_LIMITE_CUOTA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MNT_CUOTA_COMPLETADA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    COD_CUOTA_LOCAL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_MATERIAL = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUOTA_LOCAL_DET", x => x.COD_CUOTA_LOCAL_DET);
                    table.ForeignKey(
                        name: "FK_PGSTB_CUOTA_LOCAL_DET_PGSTB_CUOTA_LOCAL",
                        column: x => x.COD_CUOTA_LOCAL,
                        principalSchema: "dbo",
                        principalTable: "PGSTB_CUOTA_LOCAL",
                        principalColumn: "COD_CUOTA_LOCAL",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PGSTB_CUOTA_LOCAL_DET_PGSTB_MATERIAL",
                        column: x => x.COD_MATERIAL,
                        principalTable: "PGSTB_MATERIAL",
                        principalColumn: "COD_MATERIAL");
                });

            migrationBuilder.CreateTable(
                name: "PGSTB_PROVEEDOR",
                schema: "dbo",
                columns: table => new
                {
                    COD_PROVEEDOR = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_PROVEEDOR_SAP = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: true),
                    COD_LOCAL_PROVEEDOR_SAP = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: true),
                    NUM_RUC = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    DSC_NOMBRE_RAZON_SOCIAL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DSC_TIPO_PROGRESOL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FLAG_ACTIVO = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    COD_TIPO_PROVEEDOR = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVEEDOR", x => x.COD_PROVEEDOR);
                    table.ForeignKey(
                        name: "FK_PGSTB_PROVEEDOR_PGSTB_TIPO_PROVEEDOR",
                        column: x => x.COD_TIPO_PROVEEDOR,
                        principalSchema: "dbo",
                        principalTable: "PGSTB_TIPO_PROVEEDOR",
                        principalColumn: "COD_TIPO_PROVEEDOR");
                });

            migrationBuilder.CreateTable(
                name: "PGSTB_COMPRA_MINORISTA",
                schema: "dbo",
                columns: table => new
                {
                    COD_COMPRA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NUM_CORRELATIVO_COMPRA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FCH_REGISTRO = table.Column<DateTime>(type: "datetime", nullable: false),
                    MNT_TOTAL_BOLSAS = table.Column<int>(type: "int", nullable: false),
                    FLAG_ACTIVO = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    COD_PROGRESOL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_PROVEEDOR = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_TIPO_COMPRA = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPRA_MINORISTA", x => x.COD_COMPRA);
                    table.ForeignKey(
                        name: "FK_PGSTB_COMPRA_MINORISTA_PGSTB_PROVEEDOR",
                        column: x => x.COD_PROVEEDOR,
                        principalSchema: "dbo",
                        principalTable: "PGSTB_PROVEEDOR",
                        principalColumn: "COD_PROVEEDOR");
                    table.ForeignKey(
                        name: "FK_PGSTB_COMPRA_MINORISTA_PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                        column: x => x.COD_PROGRESOL,
                        principalTable: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                        principalColumn: "COD_PROGRESOL");
                    table.ForeignKey(
                        name: "FK_PGSTB_COMPRA_MINORISTA_PGSTB_TIPO_COMPRA",
                        column: x => x.COD_TIPO_COMPRA,
                        principalSchema: "dbo",
                        principalTable: "PGSTB_TIPO_COMPRA",
                        principalColumn: "COD_TIPO_COMPRA");
                });

            migrationBuilder.CreateTable(
                name: "PGSTB_PROVEEDOR_MATERIAL",
                schema: "dbo",
                columns: table => new
                {
                    COD_PROVEEDOR_MATERIAL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_MATERIAL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_PROVEEDOR = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_LOCAL_PROGRESOL_SAP = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    FLAG_ACTIVO = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVEEDOR_MATERIAL", x => x.COD_PROVEEDOR_MATERIAL);
                    table.ForeignKey(
                        name: "FK_PGSTB_PROVEEDOR_MATERIAL_PGSTB_MATERIAL",
                        column: x => x.COD_MATERIAL,
                        principalTable: "PGSTB_MATERIAL",
                        principalColumn: "COD_MATERIAL");
                    table.ForeignKey(
                        name: "FK_PGSTB_PROVEEDOR_MATERIAL_PGSTB_PROVEEDOR",
                        column: x => x.COD_PROVEEDOR,
                        principalSchema: "dbo",
                        principalTable: "PGSTB_PROVEEDOR",
                        principalColumn: "COD_PROVEEDOR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PGSTB_COMPRA_MINORISTA_DET",
                schema: "dbo",
                columns: table => new
                {
                    COD_COMPRA_DETALLE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NUM_CANTIDAD = table.Column<int>(type: "int", nullable: false),
                    MNT_TOTAL_BOLSAS = table.Column<int>(type: "int", nullable: false),
                    COD_MATERIAL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_COMPRA = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPRA_MINORISTA_DET", x => x.COD_COMPRA_DETALLE);
                    table.ForeignKey(
                        name: "FK_PGSTB_COMPRA_MINORISTA_DET_PGSTB_COMPRA_MINORISTA",
                        column: x => x.COD_COMPRA,
                        principalSchema: "dbo",
                        principalTable: "PGSTB_COMPRA_MINORISTA",
                        principalColumn: "COD_COMPRA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PGSTB_COMPRA_MINORISTA_DET_PGSTB_MATERIAL",
                        column: x => x.COD_MATERIAL,
                        principalTable: "PGSTB_MATERIAL",
                        principalColumn: "COD_MATERIAL");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_COMPRA_MINORISTA_COD_PROGRESOL",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA",
                column: "COD_PROGRESOL");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_COMPRA_MINORISTA_COD_PROVEEDOR",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA",
                column: "COD_PROVEEDOR");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_COMPRA_MINORISTA_COD_TIPO_COMPRA",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA",
                column: "COD_TIPO_COMPRA");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_COMPRA_MINORISTA_DET_COD_COMPRA",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA_DET",
                column: "COD_COMPRA");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_COMPRA_MINORISTA_DET_COD_MATERIAL",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA_DET",
                column: "COD_MATERIAL");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_CUOTA_LOCAL_COD_PROGRESOL",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL",
                column: "COD_PROGRESOL");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_CUOTA_LOCAL_DET_COD_CUOTA_LOCAL",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL_DET",
                column: "COD_CUOTA_LOCAL");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_CUOTA_LOCAL_DET_COD_MATERIAL",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL_DET",
                column: "COD_MATERIAL");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_PROVEEDOR_COD_TIPO_PROVEEDOR",
                schema: "dbo",
                table: "PGSTB_PROVEEDOR",
                column: "COD_TIPO_PROVEEDOR");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_PROVEEDOR_MATERIAL_COD_MATERIAL",
                schema: "dbo",
                table: "PGSTB_PROVEEDOR_MATERIAL",
                column: "COD_MATERIAL");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_PROVEEDOR_MATERIAL_COD_PROVEEDOR",
                schema: "dbo",
                table: "PGSTB_PROVEEDOR_MATERIAL",
                column: "COD_PROVEEDOR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PGSTB_COMPRA_MINORISTA_DET",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PGSTB_CUOTA_LOCAL_DET",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PGSTB_PROVEEDOR_MATERIAL",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PGSTB_COMPRA_MINORISTA",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PGSTB_CUOTA_LOCAL",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PGSTB_PROVEEDOR",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PGSTB_TIPO_COMPRA",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PGSTB_TIPO_PROVEEDOR",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TEMP_FUN_CLIENTESPS_SAP",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP");

            migrationBuilder.DropColumn(
                name: "FLAG_ACTIVO",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP");

            migrationBuilder.DropColumn(
                name: "FLAG_ACTUALIZA_SALDO_CUOTA",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP");

            migrationBuilder.RenameColumn(
                name: "COD_PROGRESOL",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                column: "COD_CLIENTEPS_SAP");
        }
    }
}
