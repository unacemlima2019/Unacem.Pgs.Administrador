using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Materiales;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    class ConfiguracionTipoEntidadMaterial : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK_MATERIAL");

            builder.ToTable("PGSTB_MATERIAL");

            builder.Property(e => e.Id).HasColumnName("COD_MATERIAL");

            builder.Property(e => e.CodigoProductoSap)
                .HasColumnName("COD_PRODUCTO_SAP")
                .HasMaxLength(70)
                .IsUnicode(true);

            builder.Property(e => e.Sku)
                .HasColumnName("COD_SKU")
                .HasMaxLength(90)
                .IsRequired(true)
                .IsUnicode(true);
            builder.HasIndex(e => e.Sku).IsUnique();

            builder.Property(e => e.NombreMaterial)
                .HasColumnName("DSC_NOMBRE")
                .HasMaxLength(300)
                .IsUnicode(true);

            builder.Property(e => e.NombreMaterialParser)
                .HasColumnName("DSC_PRODUCTO_PARSER")
                .HasMaxLength(300)
                .IsUnicode(true);

            builder.Property(e => e.RutaImagen)
                .HasColumnName("DSC_IMAGEN")
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.UsuarioCreacion)
                .HasColumnName("DSC_USUARIO_CREACION")
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.FechaCreacion)
                .HasColumnName("FCH_REGISTRO")
                .HasColumnType("datetime");

            builder.Property(e => e.UsuarioActualizacion)
                .HasColumnName("DSC_USUARIO_UPD")
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.FechaActualizacion)
                .HasColumnName("FCH_UPD")
                .HasColumnType("datetime");

            builder.Property(e => e.Activo)
                .HasColumnName("FLAG_ACTIVO")
                .HasMaxLength(1)
                .IsUnicode(false);

            builder.Property(e => e.OrdenMaterial)
                .HasColumnName("NUM_ORD_MATERIALCEMENTO");


            //CLAVES
            builder.Property(e => e.CodigoCategoria)
                .HasColumnName("COD_CATEGORIA_MATERIAL");

            builder.Property(e => e.CodigoTipo)
                .HasColumnName("COD_TIPO_MATERIAL");

            builder.Property(e => e.CodigoMarca)
                .HasColumnName("COD_MARCA_MATERIAL");

            builder.Property(e => e.CodigoUnidadMedida)
                .HasColumnName("COD_UNIDAD_MEDIDA");


            ////RELACIONES FORANEAS
            //builder.HasOne(d => d.Categoria)
            //    .WithMany()
            //    .HasForeignKey(d => d.CodigoCategoria)
            //    .HasConstraintName("FK_PGSTB_MATERIAL_PGSTB_CATEGORIA_MATERIAL");

            //builder.HasOne(d => d.Tipo)
            //    .WithMany()
            //    .HasForeignKey(d => d.CodigoTipo)
            //    .HasConstraintName("FK_PGSTB_MATERIAL_PGSTB_TIPO_MATERIAL");

            //builder.HasOne(d => d.Marca)
            //    .WithMany()
            //    .HasForeignKey(d => d.CodigoMarca)
            //    .HasConstraintName("FK_PGSTB_MATERIAL_PGSTB_MARCA_MATERIAL");

            //builder.HasOne(d => d.UnidadMedida)
            //    .WithMany()
            //    .HasForeignKey(d => d.CodigoUnidadMedida)
            //    .HasConstraintName("FK_PGSTB_MATERIAL_PGSTB_UNIDAD_MEDIDA");

        }
    }
}
