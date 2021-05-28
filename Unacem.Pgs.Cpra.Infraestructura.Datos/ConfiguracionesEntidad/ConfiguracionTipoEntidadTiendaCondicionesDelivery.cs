using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    public class ConfiguracionTipoEntidadTiendaCondicionesDelivery :
        IEntityTypeConfiguration<TiendaCondicionDelivery>
    {
        public void Configure(EntityTypeBuilder<TiendaCondicionDelivery> builder)
        {

            builder.HasKey(e => e.CodTiendaCondDelivery)
                    .HasName("PK_tblTienda_CondicionDelivery");

            builder.ToTable("PGSTB_TIENDA_CONDICION_DELIVERY");

            builder.Property(e => e.CodTiendaCondDelivery).HasColumnName("COD_TIENDA_COND_DELIVERY");

            builder.Property(e => e.CodCondicionDelivery).HasColumnName("COD_CONDICION_DELIVERY");

            builder.Property(e => e.CodTiendaProgresol).HasColumnName("COD_TIENDA_PROGRESOL");

            builder.Property(e => e.DscMontoMin)
                    .HasColumnName("DSC_MONTO_MIN")
                    .HasMaxLength(5)
                    .IsUnicode(false);

            builder.HasOne(d => d.CodCondicionDeliveryNavigation)
                    .WithMany(p => p.TiendaCondicionDelivery)
                    .HasForeignKey(d => d.CodCondicionDelivery)
                    .HasConstraintName("FK_tblTienda_CondicionDelivery_tblCondicionesDelivery");

            builder.HasOne(d => d.CodTiendaProgresolNavigation)
                    .WithMany(p => p.TiendaCondicionDelivery)
                    .HasForeignKey(d => d.CodTiendaProgresol)
                    .HasConstraintName("FK_tblTienda_CondicionDelivery_tblTiendaProgresol");
         
        }

    }
}
