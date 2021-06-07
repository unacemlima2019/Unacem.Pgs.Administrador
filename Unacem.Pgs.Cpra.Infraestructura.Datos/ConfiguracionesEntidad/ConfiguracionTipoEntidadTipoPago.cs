using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    public class ConfiguracionTipoEntidadTipoPago:
        IEntityTypeConfiguration<TipoPago>
    {
        public void Configure(EntityTypeBuilder<TipoPago> builder)
        {

            builder.HasKey(e => e.CodTipoPago)
                    .HasName("PK_tblTipoPago");

            builder.ToTable("PGSTB_TIPO_PAGO");

            builder.Property(e => e.CodTipoPago).HasColumnName("COD_TIPO_PAGO");

            builder.Property(e => e.DscActivo)
                .HasColumnName("DSC_ACTIVO")
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            builder.Property(e => e.DscRutaLogo)
                .HasColumnName("DSC_RUTA_LOGO")
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.DscTipoPago)
                .HasColumnName("DSC_TIPO_PAGO")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Defecto)
                .HasColumnName("DSC_DEFECTO")
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

        }
     }
}
