using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;
using Unacem.Pgs.Cpra.Infraestructura.Datos;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
   public class ConfiguracionTipoEntidadProductosDestacados
    :IEntityTypeConfiguration<ProductoDestacados>
    { 
        public void Configure(EntityTypeBuilder <ProductoDestacados> builder)
        {
            //Invalid column name 'ProductoDestacadosCodProductoDestacado'.

            builder.ToTable("PGSTB_PRODUCTO_DESTACADO", ProgresolContexto.DEFAULT_SCHEMA);

            builder.HasKey(e => e.CodProductoDestacado)
                    .HasName("PK_tblProductoDestacado");

            builder.Property(e => e.CodProductoDestacado).HasColumnName("COD_PRODUCTO_DESTACADO");

            //builder.Ignore(i => i.Id);

            builder.Property(e => e.DscActivo)
                    .HasColumnName("DSC_ACTIVO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

            builder.Property(e => e.DscCategoria)
                    .HasColumnName("DSC_CATEGORIA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.DscNombre)
                    .HasColumnName("DSC_NOMBRE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.DscRuta)
                    .HasColumnName("DSC_RUTA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.FchActualizacion)
                    .HasColumnName("FCH_ACTUALIZACION")
                    .HasColumnType("datetime");

                builder.Property(e => e.FchCreacion)
                    .HasColumnName("FCH_CREACION")
                    .HasColumnType("datetime");
     
        }
    }
}
