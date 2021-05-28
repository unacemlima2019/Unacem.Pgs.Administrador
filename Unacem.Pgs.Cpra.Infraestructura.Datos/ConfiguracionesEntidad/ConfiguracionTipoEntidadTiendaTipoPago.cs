using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    public class ConfiguracionTipoEntidadTiendaTipoPago:
        IEntityTypeConfiguration<TiendaTipoPago>
    {
        public void Configure(EntityTypeBuilder<TiendaTipoPago> builder)
        {

            builder.HasKey(e => e.CodTiendaTipoPago)
                    .HasName("PK_tblTienda_TipoPago");

            builder.ToTable("PGSTB_TIENDA_TIPO_PAGO");

            builder.Property(e => e.CodTiendaTipoPago).HasColumnName("COD_TIENDA_TIPO_PAGO");

            builder.Property(e => e.CodTiendaProgresol).HasColumnName("COD_TIENDA_PROGRESOL");

            builder.Property(e => e.CodTipoPago).HasColumnName("COD_TIPO_PAGO");

            builder.HasOne(d => d.CodTiendaProgresolNavigation)
                    .WithMany(p => p.TiendaTipoPago)
                    .HasForeignKey(d => d.CodTiendaProgresol)
                    .HasConstraintName("FK_tblTienda_TipoPago_tblTiendaProgresol");

            builder.HasOne(d => d.CodTipoPagoNavigation)
                    .WithMany(p => p.TiendaTipoPago)
                    .HasForeignKey(d => d.CodTipoPago)
                    .HasConstraintName("FK_tblTienda_TipoPago_tblTipoPago");
           
        }
    }
}
