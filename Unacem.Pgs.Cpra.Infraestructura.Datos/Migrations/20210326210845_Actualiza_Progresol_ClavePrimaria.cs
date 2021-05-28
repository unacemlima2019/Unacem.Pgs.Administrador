using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Unacem.Pgs.Cpra.Infraestructura.Datos.Migrations
{
    public partial class Actualiza_Progresol_ClavePrimaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PGSTB_COMPRA_MINORISTA_PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA");

            migrationBuilder.DropForeignKey(
                name: "FK_PGSTB_CUOTA_LOCAL_PGSTB_PROGRESOL",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TEMP_FUN_CLIENTESPS_SAP",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP");

            migrationBuilder.DropIndex(
                name: "IX_PGSTB_CUOTA_LOCAL_COD_PROGRESOL",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL");

            migrationBuilder.DropIndex(
                name: "IX_PGSTB_COMPRA_MINORISTA_COD_PROGRESOL",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA");

            migrationBuilder.DropColumn(
                name: "COD_PROGRESOL",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP");

            migrationBuilder.DropColumn(
                name: "COD_PROGRESOL",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL");

            migrationBuilder.DropColumn(
                name: "COD_PROGRESOL",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA");

            migrationBuilder.RenameColumn(
                name: "COD_LOCAL_PROGRESOL_SAP",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL",
                newName: "COD_PDV");

            migrationBuilder.AlterColumn<string>(
                name: "COD_PDV",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "COD_PDV",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(70)",
                oldUnicode: false,
                oldMaxLength: 70,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "COD_PDV",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TEMP_FUN_CLIENTESPS_SAP_X_LOCAL",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                column: "COD_PDV");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_CUOTA_LOCAL_COD_PDV",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL",
                column: "COD_PDV");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_COMPRA_MINORISTA_COD_PDV",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA",
                column: "COD_PDV");

            migrationBuilder.AddForeignKey(
                name: "FK_PGSTB_COMPRA_MINORISTA_PGSTB_TEMP_FUN_CLIENTESPS_SAP_X_LOCAL",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA",
                column: "COD_PDV",
                principalTable: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                principalColumn: "COD_PDV");

            migrationBuilder.AddForeignKey(
                name: "FK_PGSTB_CUOTA_LOCAL_PGSTB_PROGRESOL_X_LOCAL",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL",
                column: "COD_PDV",
                principalTable: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                principalColumn: "COD_PDV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PGSTB_COMPRA_MINORISTA_PGSTB_TEMP_FUN_CLIENTESPS_SAP_X_LOCAL",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA");

            migrationBuilder.DropForeignKey(
                name: "FK_PGSTB_CUOTA_LOCAL_PGSTB_PROGRESOL_X_LOCAL",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TEMP_FUN_CLIENTESPS_SAP_X_LOCAL",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP");

            migrationBuilder.DropIndex(
                name: "IX_PGSTB_CUOTA_LOCAL_COD_PDV",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL");

            migrationBuilder.DropIndex(
                name: "IX_PGSTB_COMPRA_MINORISTA_COD_PDV",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA");

            migrationBuilder.DropColumn(
                name: "COD_PDV",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA");

            migrationBuilder.RenameColumn(
                name: "COD_PDV",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL",
                newName: "COD_LOCAL_PROGRESOL_SAP");

            migrationBuilder.AlterColumn<string>(
                name: "COD_PDV",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10);

            migrationBuilder.AddColumn<Guid>(
                name: "COD_PROGRESOL",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "COD_LOCAL_PROGRESOL_SAP",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL",
                type: "varchar(70)",
                unicode: false,
                maxLength: 70,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "COD_PROGRESOL",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "COD_PROGRESOL",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TEMP_FUN_CLIENTESPS_SAP",
                table: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                column: "COD_PROGRESOL");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_CUOTA_LOCAL_COD_PROGRESOL",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL",
                column: "COD_PROGRESOL");

            migrationBuilder.CreateIndex(
                name: "IX_PGSTB_COMPRA_MINORISTA_COD_PROGRESOL",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA",
                column: "COD_PROGRESOL");

            migrationBuilder.AddForeignKey(
                name: "FK_PGSTB_COMPRA_MINORISTA_PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                schema: "dbo",
                table: "PGSTB_COMPRA_MINORISTA",
                column: "COD_PROGRESOL",
                principalTable: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                principalColumn: "COD_PROGRESOL");

            migrationBuilder.AddForeignKey(
                name: "FK_PGSTB_CUOTA_LOCAL_PGSTB_PROGRESOL",
                schema: "dbo",
                table: "PGSTB_CUOTA_LOCAL",
                column: "COD_PROGRESOL",
                principalTable: "PGSTB_TEMP_FUN_CLIENTESPS_SAP",
                principalColumn: "COD_PROGRESOL");
        }
    }
}
