using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    public class ConfiguracionTipoEntidadTiendaTiempoEntrega :
        IEntityTypeConfiguration<TiendaTiempoEntrega>
    {
        public void Configure(EntityTypeBuilder<TiendaTiempoEntrega> builder)
        {

            builder.HasKey(e => e.CodTiendaTiempoEntrega)
                    .HasName("PK_tblTienda_TiempoEntrega");

            builder.ToTable("PGSTB_TIENDA_TIEMPO_ENTREGA");

            builder.Property(e => e.CodTiendaTiempoEntrega).HasColumnName("COD_TIENDA_TIEMPO_ENTREGA");

            builder.Property(e => e.CodTiempoEntrega).HasColumnName("COD_TIEMPO_ENTREGA");

            builder.Property(e => e.CodTiendaProgresol).HasColumnName("COD_TIENDA_PROGRESOL");

            builder.HasOne(d => d.CodTiempoEntregaNavigation)
                    .WithMany(p => p.TiendaTiempoEntrega)
                    .HasForeignKey(d => d.CodTiempoEntrega)
                    .HasConstraintName("FK_tblTienda_TiempoEntrega_tblTiempoEntrega");

            builder.HasOne(d => d.CodTiendaProgresolNavigation)
                    .WithMany(p => p.TiendaTiempoEntrega)
                    .HasForeignKey(d => d.CodTiendaProgresol)
                    .HasConstraintName("FK_tblTienda_TiempoEntrega_tblTiendaProgresol");
          
        }
     }
}
