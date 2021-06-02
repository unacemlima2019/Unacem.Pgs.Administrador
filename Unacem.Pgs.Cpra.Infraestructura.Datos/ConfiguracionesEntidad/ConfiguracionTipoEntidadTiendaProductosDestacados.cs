using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    public class ConfiguracionTipoEntidadTiendaProductosDestacados :
        IEntityTypeConfiguration<TiendaProductoDestacados>
    {
        public void Configure(EntityTypeBuilder<TiendaProductoDestacados> builder)
        {

            builder.HasKey(e => e.CodTiendaProductoDestacado);

            builder.ToTable("PGSTB_TIENDA_PRODUCTO_DESTACADO");

            builder.Property(e => e.CodTiendaProductoDestacado).HasColumnName("COD_TIENDA_PRODUCTO_DESTACADO");

            builder.Property(e => e.CodProductoDestacado).HasColumnName("COD_PRODUCTO_DESTACADO");

            builder.Property(e => e.CodTiendaProgresol).HasColumnName("COD_TIENDA_PROGRESOL");

            builder.HasOne(d => d.CodProductoDestacadoNavigation)
                    .WithMany(p => p.TiendaProductosDestacado)
                    .HasForeignKey(d => d.CodProductoDestacado)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PGSTB_TIENDA_PRODUCTO_DESTACADO_PGSTB_TIENDA_PRODUCTO_DESTACADO");

            builder.HasOne(d => d.CodTiendaProgresolNavigation)
                    .WithMany(p => p.TiendaProductosDestacados)
                    .HasForeignKey(d => d.CodTiendaProgresol)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PGSTB_TIENDA_PRODUCTO_DESTACADO_PGSTB_TIENDA_PROGRESOL");
            
        }
    }
}
