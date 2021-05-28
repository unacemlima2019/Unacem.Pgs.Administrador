using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    public class ConfiguracionTipoEntidadTiempoEntrega:
        IEntityTypeConfiguration<TiempoEntrega>
    {
        public void Configure(EntityTypeBuilder<TiempoEntrega> builder)
        {

            builder.HasKey(e => e.CodTiempoEntrega)
                    .HasName("PK_tblTiempoEntrega");

            builder.ToTable("PGSTB_TIEMPO_ENTREGA");

            builder.Property(e => e.CodTiempoEntrega).HasColumnName("COD_TIEMPO_ENTREGA");

            builder.Property(e => e.DscActivo)
                    .HasColumnName("DSC_ACTIVO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

            builder.Property(e => e.DscTiempoEntrega)
                    .HasColumnName("DSC_TIEMPO_ENTREGA")
                    .HasMaxLength(100)
                    .IsUnicode(false);
        }
    }
}
