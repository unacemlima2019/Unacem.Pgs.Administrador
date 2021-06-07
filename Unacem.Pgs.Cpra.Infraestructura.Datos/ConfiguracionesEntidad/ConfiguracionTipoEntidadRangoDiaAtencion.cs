using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    public class ConfiguracionTipoEntidadRangoDiaAtencion: IEntityTypeConfiguration<RangoDiaAtencion>
    {
        public void Configure(EntityTypeBuilder<RangoDiaAtencion> builder)
        {
            builder.HasKey(e => e.CodRangoDiaAtencion)
                    .HasName("PK_PGSTB_HORARIO_ATENCION");

            builder.ToTable("PGSTB_RANGO_DIA_ATENCION");

            builder.Property(e => e.CodRangoDiaAtencion).HasColumnName("COD_RANGO_DIA_ATENCION");

            builder.Property(e => e.DscRangoDia)
                    .IsRequired()
                    .HasColumnName("DSC_RANGO_DIA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

            builder.Property(e => e.Defecto)
                    .HasColumnName("DSC_DEFECTO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
        }
    }
}
