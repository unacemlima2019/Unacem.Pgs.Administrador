using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Videos;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
   public class ConfiguracionTipoEntidadVideo:IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.HasKey(e => e.CodVideo);

            builder.ToTable("PGSTB_VIDEO");

            builder.Property(e => e.CodVideo).HasColumnName("COD_VIDEO");

            builder.Property(e => e.CodTipoVideo).HasColumnName("COD_TIPO_VIDEO");

            builder.Property(e => e.DscActivo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DSC_ACTIVO")
                .IsFixedLength(true);

            builder.Property(e => e.DscDireccionUrl)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("DSC_DIRECCION_URL");

            builder.Property(e => e.DscOrden)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("DSC_ORDEN")
                .IsFixedLength(true);

            builder.Property(e => e.DscTitulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DSC_TITULO");

            builder.Property(e => e.DscVideo)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("DSC_VIDEO");

            builder.Property(e => e.FchRegistro)
                .HasColumnType("datetime")
                .HasColumnName("FCH_REGISTRO");

            builder.HasOne(d => d.CodTipoVideoNavigation)
                .WithMany(p => p.Videos)
                .HasForeignKey(d => d.CodTipoVideo)
                .HasConstraintName("FK__PGSTB_VID__COD_T__4B05610F");
        }

   
    }
}
