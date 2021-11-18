using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Videos;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    public class ConfiguracionTipoEntidadTipoVideo : IEntityTypeConfiguration<TipoVideo>
    {
        public void Configure(EntityTypeBuilder<TipoVideo> builder)
        {
            builder.HasKey(e => e.CodTipoVideo);

            builder.ToTable("PGSTB_TIPO_VIDEO");

            builder.Property(e => e.CodTipoVideo).HasColumnName("COD_TIPO_VIDEO");

            builder.Property(e => e.DscActivo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DSC_ACTIVO")
                .IsFixedLength(true);

            builder.Property(e => e.DscTipo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DSC_TIPO");

            builder.Property(e => e.FchRegistro)
                .HasColumnType("datetime")
                .HasColumnName("FCH_REGISTRO");

            builder.Property(e => e.Id).HasColumnName("ID");
        }
    }
}
