using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.Migrations
{
    public partial class JIUNCM_Inicio_EntidadesFiltroMateriales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "PGSTB_CARACTERISTICA",
                schema: "dbo",
                columns: table => new
                {
                    COD_CARACTERISTICA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_CARACTERISTICA_SAP = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: true),
                    DSC_CARACTERISTICA = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FLAG_ACTIVO = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARACTERISTICA", x => x.COD_CARACTERISTICA);
                });

            migrationBuilder.CreateTable(
                name: "PGSTB_USO",
                schema: "dbo",
                columns: table => new
                {
                    COD_USO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_USO_SAP = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: true),
                    DSC_USO = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FLAG_ACTIVO = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USO", x => x.COD_USO);
                });



            migrationBuilder.CreateTable(
                name: "PGSTB_CARACTERISTICA_MATERIAL",
                schema: "dbo",
                columns: table => new
                {
                    COD_CARACTERISTICA_MATERIAL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_CARACTERISTICA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_MATERIAL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DSC_DETALLE_CARACTERISTICA_MATERIAL = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FLAG_ACTIVO = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARACTERISTICA_MATERIAL", x => x.COD_CARACTERISTICA_MATERIAL);
                    table.ForeignKey(
                        name: "FK_PGSTB_CARACTERISTICA_MATERIAL_PGSTB_CARACTERISTICA",
                        column: x => x.COD_CARACTERISTICA,
                        principalSchema: "dbo",
                        principalTable: "PGSTB_CARACTERISTICA",
                        principalColumn: "COD_CARACTERISTICA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PGSTB_CARACTERISTICA_MATERIAL_PGSTB_MATERIAL",
                        column: x => x.COD_MATERIAL,
                        principalTable: "PGSTB_MATERIAL",
                        principalColumn: "COD_MATERIAL");
                });


            migrationBuilder.CreateTable(
                name: "PGSTB_USO_MATERIAL",
                schema: "dbo",
                columns: table => new
                {
                    COD_USO_MATERIAL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_USO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_MATERIAL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DSC_DETALLE_USO_MATERIAL = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FLAG_ACTIVO = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USO_MATERIAL", x => x.COD_USO_MATERIAL);
                    table.ForeignKey(
                        name: "FK_PGSTB_USO_MATERIAL_PGSTB_MATERIAL",
                        column: x => x.COD_MATERIAL,
                        principalTable: "PGSTB_MATERIAL",
                        principalColumn: "COD_MATERIAL");
                    table.ForeignKey(
                        name: "FK_PGSTB_USO_MATERIAL_PGSTB_USO",
                        column: x => x.COD_USO,
                        principalSchema: "dbo",
                        principalTable: "PGSTB_USO",
                        principalColumn: "COD_USO",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_CARACTERISTICA_MATERIAL_COD_CARACTERISTICA",
                schema: "dbo",
                table: "PGSTB_CARACTERISTICA_MATERIAL",
                column: "COD_CARACTERISTICA");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_CARACTERISTICA_MATERIAL_COD_MATERIAL",
                schema: "dbo",
                table: "PGSTB_CARACTERISTICA_MATERIAL",
                column: "COD_MATERIAL");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_USO_MATERIAL_COD_MATERIAL",
                schema: "dbo",
                table: "PGSTB_USO_MATERIAL",
                column: "COD_MATERIAL");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_USO_MATERIAL_COD_USO",
                schema: "dbo",
                table: "PGSTB_USO_MATERIAL",
                column: "COD_USO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PGSTB_CARACTERISTICA_MATERIAL",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PGSTB_USO_MATERIAL",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PGSTB_CARACTERISTICA",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PGSTB_USO",
                schema: "dbo");


        }
    }
}
