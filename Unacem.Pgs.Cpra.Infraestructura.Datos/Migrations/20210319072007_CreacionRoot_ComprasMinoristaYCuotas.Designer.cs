﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Unacem.Pgs.Cpra.Infraestructura.Datos;

namespace Unacem.Pgs.Cpra.Infraestructura.Datos.Migrations
{
    [DbContext(typeof(ProgresolContexto))]
    [Migration("20210319072007_CreacionRoot_ComprasMinoristaYCuotas")]
    partial class CreacionRoot_ComprasMinoristaYCuotas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_CATEGORIA_MATERIAL");

                    b.Property<string>("Activo")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("FLAG_ACTIVO");

                    b.Property<string>("CodigoCategoriaSap")
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("COD_CATEGORIA_SAP");

                    b.Property<string>("NombreCategoria")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DSC_NOMBRE");

                    b.Property<string>("RutaImagen")
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("DSC_IMAGEN");

                    b.HasKey("Id")
                        .HasName("PK_CATEGORIA_MATERIAL");

                    b.ToTable("PGSTB_CATEGORIA_MATERIAL");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Compra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_COMPRA");

                    b.Property<string>("Activo")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("FLAG_ACTIVO");

                    b.Property<Guid>("CodigoProgresol")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_PROGRESOL");

                    b.Property<Guid>("CodigoProveedor")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_PROVEEDOR");

                    b.Property<Guid>("CodigoTipoCompra")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_TIPO_COMPRA");

                    b.Property<DateTime>("FechaRegistroCompra")
                        .HasColumnType("datetime")
                        .HasColumnName("FCH_REGISTRO");

                    b.Property<int>("NumeroCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NUM_CORRELATIVO_COMPRA")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TotalBolsas")
                        .HasColumnType("int")
                        .HasColumnName("MNT_TOTAL_BOLSAS");

                    b.HasKey("Id")
                        .HasName("PK_COMPRA_MINORISTA");

                    b.HasIndex("CodigoProgresol");

                    b.HasIndex("CodigoProveedor");

                    b.HasIndex("CodigoTipoCompra");

                    b.ToTable("PGSTB_COMPRA_MINORISTA", "dbo");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.CompraDetalle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_COMPRA_DETALLE");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("NUM_CANTIDAD");

                    b.Property<Guid>("CodigoCompra")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_COMPRA");

                    b.Property<Guid>("CodigoMaterial")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_MATERIAL");

                    b.Property<int>("TotalBolsas")
                        .HasColumnType("int")
                        .HasColumnName("MNT_TOTAL_BOLSAS");

                    b.HasKey("Id")
                        .HasName("PK_COMPRA_MINORISTA_DET");

                    b.HasIndex("CodigoCompra");

                    b.HasIndex("CodigoMaterial");

                    b.ToTable("PGSTB_COMPRA_MINORISTA_DET", "dbo");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_MATERIAL");

                    b.Property<string>("Activo")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("FLAG_ACTIVO");

                    b.Property<Guid>("CodigoCategoria")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_CATEGORIA_MATERIAL");

                    b.Property<string>("CodigoProductoSap")
                        .HasMaxLength(70)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("COD_PRODUCTO_SAP");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime")
                        .HasColumnName("FCH_UPD");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime")
                        .HasColumnName("FCH_REGISTRO");

                    b.Property<string>("NombreMaterial")
                        .HasMaxLength(300)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("DSC_NOMBRE");

                    b.Property<string>("NombreMaterialParser")
                        .HasMaxLength(300)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("DSC_PRODUCTO_PARSER");

                    b.Property<decimal>("OrdenMaterial")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("NUM_ORD_MATERIALCEMENTO");

                    b.Property<string>("RutaImagen")
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("DSC_IMAGEN");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasMaxLength(90)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(90)")
                        .HasColumnName("COD_SKU");

                    b.Property<string>("UsuarioActualizacion")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DSC_USUARIO_UPD");

                    b.Property<string>("UsuarioCreacion")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DSC_USUARIO_CREACION");

                    b.HasKey("Id")
                        .HasName("PK_MATERIAL");

                    b.HasIndex("CodigoCategoria");

                    b.HasIndex("Sku")
                        .IsUnique();

                    b.ToTable("PGSTB_MATERIAL");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Progresol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_PROGRESOL");

                    b.Property<string>("Activo")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("FLAG_ACTIVO");

                    b.Property<string>("CelularDueño")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("DSC_CELULAR_DUENO");

                    b.Property<string>("CodigoLocalProgresolSap")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("COD_PDV");

                    b.Property<string>("CodigoProgresolHijoSap")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("COD_HIJO");

                    b.Property<string>("CodigoProgresolSap")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("COD_PADRE");

                    b.Property<int>("CorrelativoCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("COD_CLIENTEPS_SAP")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Departamento")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("DSC_DEPARTAMENTO");

                    b.Property<string>("Direccion")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DSC_DIRECCION");

                    b.Property<string>("Distrito")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("DSC_DISTRITO");

                    b.Property<bool>("EsActualizableSaldosCuota")
                        .HasColumnType("bit")
                        .HasColumnName("FLAG_ACTUALIZA_SALDO_CUOTA");

                    b.Property<string>("FlagTienda")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .HasColumnName("DSC_FLAG_TIENDA")
                        .IsFixedLength(true);

                    b.Property<string>("HorarioAtencion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("DSC_HORARIO_ATENCION");

                    b.Property<string>("Latitud")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("DSC_LATITUD");

                    b.Property<string>("LogoTienda")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("DSC_LOGO_TIENDA");

                    b.Property<string>("Longitud")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("DSC_LONGITUD");

                    b.Property<string>("NombreComercial")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DSC_NOMBRE_COMERCIAL");

                    b.Property<string>("NombreORazonSocialProgresol")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DSC_RAZON_SOCIAL");

                    b.Property<string>("Provincia")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("DSC_PROVINCIA");

                    b.Property<string>("TipoProgresol")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("DSC_TIPO_PROGRESOL");

                    b.HasKey("Id")
                        .HasName("PK_TEMP_FUN_CLIENTESPS_SAP");

                    b.ToTable("PGSTB_TEMP_FUN_CLIENTESPS_SAP");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Proveedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_PROVEEDOR");

                    b.Property<string>("Activo")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("FLAG_ACTIVO");

                    b.Property<string>("CodigoLocalProveedorSap")
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("COD_LOCAL_PROVEEDOR_SAP");

                    b.Property<string>("CodigoProveedorSap")
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("COD_PROVEEDOR_SAP");

                    b.Property<Guid>("CodigoTipoProveedor")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_TIPO_PROVEEDOR");

                    b.Property<string>("NombreORazonSocialProveedor")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DSC_NOMBRE_RAZON_SOCIAL");

                    b.Property<string>("RucProveedor")
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("NUM_RUC");

                    b.Property<string>("TipoProgresol")
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("DSC_TIPO_PROGRESOL");

                    b.HasKey("Id")
                        .HasName("PK_PROVEEDOR");

                    b.HasIndex("CodigoTipoProveedor");

                    b.ToTable("PGSTB_PROVEEDOR", "dbo");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.ProveedorMaterial", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_PROVEEDOR_MATERIAL");

                    b.Property<string>("Activo")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("FLAG_ACTIVO");

                    b.Property<string>("CodigoLocalProgresolSap")
                        .HasMaxLength(70)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("COD_LOCAL_PROGRESOL_SAP");

                    b.Property<Guid>("CodigoMaterial")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_MATERIAL");

                    b.Property<Guid>("CodigoProveedor")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_PROVEEDOR");

                    b.HasKey("Id")
                        .HasName("PK_PROVEEDOR_MATERIAL");

                    b.HasIndex("CodigoMaterial");

                    b.HasIndex("CodigoProveedor");

                    b.ToTable("PGSTB_PROVEEDOR_MATERIAL", "dbo");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.TipoCompra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_TIPO_COMPRA");

                    b.Property<string>("Activo")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("FLAG_ACTIVO");

                    b.Property<string>("DescripcionTipoCompra")
                        .HasMaxLength(90)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(90)")
                        .HasColumnName("DSC_TIPO_COMPRA");

                    b.HasKey("Id")
                        .HasName("PK_TIPO_COMPRA");

                    b.ToTable("PGSTB_TIPO_COMPRA", "dbo");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.TipoProveedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_TIPO_PROVEEDOR");

                    b.Property<string>("AbreviaturaTipoProveedor")
                        .HasMaxLength(10)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("DSC_ABREV_TIPO_PROVEEDOR");

                    b.Property<string>("Activo")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("FLAG_ACTIVO");

                    b.Property<string>("DescripcionTipoProveedor")
                        .HasMaxLength(90)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(90)")
                        .HasColumnName("DSC_TIPO_PROVEEDOR");

                    b.HasKey("Id")
                        .HasName("PK_TIPO_PROVEEDOR");

                    b.ToTable("PGSTB_TIPO_PROVEEDOR", "dbo");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Cuotas.CuotaProgresol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_CUOTA_LOCAL");

                    b.Property<string>("Activo")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("FLAG_ACTIVO");

                    b.Property<string>("CodigoLocalProgresolSap")
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("COD_LOCAL_PROGRESOL_SAP");

                    b.Property<Guid>("CodigoProgresol")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_PROGRESOL");

                    b.Property<decimal>("CuotaCompletada")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MNT_CUOTA_COMPLETADA");

                    b.Property<decimal>("LimiteCuota")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MNT_LIMITE_CUOTA");

                    b.Property<string>("Periodo")
                        .HasMaxLength(7)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(7)")
                        .HasColumnName("DSC_PERIODO");

                    b.HasKey("Id")
                        .HasName("PK_CUOTA_LOCAL");

                    b.HasIndex("CodigoProgresol");

                    b.ToTable("PGSTB_CUOTA_LOCAL", "dbo");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Cuotas.CuotaProgresolDetalle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_CUOTA_LOCAL_DET");

                    b.Property<Guid>("CodigoCuotaProgresol")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_CUOTA_LOCAL");

                    b.Property<Guid>("CodigoMaterial")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COD_MATERIAL");

                    b.Property<decimal>("CuotaCompletadaPorMaterial")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MNT_CUOTA_COMPLETADA");

                    b.Property<decimal>("LimiteCuotaPorMaterial")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MNT_LIMITE_CUOTA");

                    b.HasKey("Id")
                        .HasName("PK_CUOTA_LOCAL_DET");

                    b.HasIndex("CodigoCuotaProgresol");

                    b.HasIndex("CodigoMaterial");

                    b.ToTable("PGSTB_CUOTA_LOCAL_DET", "dbo");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Compra", b =>
                {
                    b.HasOne("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Progresol", null)
                        .WithMany()
                        .HasForeignKey("CodigoProgresol")
                        .HasConstraintName("FK_PGSTB_COMPRA_MINORISTA_PGSTB_TEMP_FUN_CLIENTESPS_SAP")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("CodigoProveedor")
                        .HasConstraintName("FK_PGSTB_COMPRA_MINORISTA_PGSTB_PROVEEDOR")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.TipoCompra", null)
                        .WithMany()
                        .HasForeignKey("CodigoTipoCompra")
                        .HasConstraintName("FK_PGSTB_COMPRA_MINORISTA_PGSTB_TIPO_COMPRA")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.CompraDetalle", b =>
                {
                    b.HasOne("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Compra", "Compra")
                        .WithMany("CompraDetalles")
                        .HasForeignKey("CodigoCompra")
                        .HasConstraintName("FK_PGSTB_COMPRA_MINORISTA_DET_PGSTB_COMPRA_MINORISTA")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Material", "Material")
                        .WithMany()
                        .HasForeignKey("CodigoMaterial")
                        .HasConstraintName("FK_PGSTB_COMPRA_MINORISTA_DET_PGSTB_MATERIAL")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Compra");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Material", b =>
                {
                    b.HasOne("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CodigoCategoria")
                        .HasConstraintName("FK_PGSTB_MATERIAL_PGSTB_CATEGORIA_MATERIAL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Proveedor", b =>
                {
                    b.HasOne("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.TipoProveedor", "TipoProveedor")
                        .WithMany()
                        .HasForeignKey("CodigoTipoProveedor")
                        .HasConstraintName("FK_PGSTB_PROVEEDOR_PGSTB_TIPO_PROVEEDOR")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("TipoProveedor");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.ProveedorMaterial", b =>
                {
                    b.HasOne("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Material", null)
                        .WithMany()
                        .HasForeignKey("CodigoMaterial")
                        .HasConstraintName("FK_PGSTB_PROVEEDOR_MATERIAL_PGSTB_MATERIAL")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Proveedor", "Proveedor")
                        .WithMany("ProveedorMateriales")
                        .HasForeignKey("CodigoProveedor")
                        .HasConstraintName("FK_PGSTB_PROVEEDOR_MATERIAL_PGSTB_PROVEEDOR")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Cuotas.CuotaProgresol", b =>
                {
                    b.HasOne("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Progresol", "Progresol")
                        .WithMany()
                        .HasForeignKey("CodigoProgresol")
                        .HasConstraintName("FK_PGSTB_CUOTA_LOCAL_PGSTB_PROGRESOL")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Progresol");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Cuotas.CuotaProgresolDetalle", b =>
                {
                    b.HasOne("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Cuotas.CuotaProgresol", "CuotaProgresol")
                        .WithMany("CuotaProgresolDetalles")
                        .HasForeignKey("CodigoCuotaProgresol")
                        .HasConstraintName("FK_PGSTB_CUOTA_LOCAL_DET_PGSTB_CUOTA_LOCAL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Material", "Material")
                        .WithMany()
                        .HasForeignKey("CodigoMaterial")
                        .HasConstraintName("FK_PGSTB_CUOTA_LOCAL_DET_PGSTB_MATERIAL")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CuotaProgresol");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Compra", b =>
                {
                    b.Navigation("CompraDetalles");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Compras.Proveedor", b =>
                {
                    b.Navigation("ProveedorMateriales");
                });

            modelBuilder.Entity("Unacem.Pgs.Cpra.AplicacionCore.Agregados.Cuotas.CuotaProgresol", b =>
                {
                    b.Navigation("CuotaProgresolDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
