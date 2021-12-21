using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Materiales;
using Unacem.Pgs.Cpra.Infraestructura.Datos;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    class ConfiguracionTipoEntidadCaracteristica : IEntityTypeConfiguration<Caracteristica>
    {
        public void Configure(EntityTypeBuilder<Caracteristica> builder)
        {
            builder.ToTable("PGSTB_CARACTERISTICA", ProgresolContexto.DEFAULT_SCHEMA);

            builder.HasKey(e => e.Id)
                .HasName("PK_CARACTERISTICA");

            builder.Property(e => e.Id).HasColumnName("COD_CARACTERISTICA");

            builder.Property(e => e.CodigoCaracteristicaSap)
                .HasColumnName("COD_CARACTERISTICA_SAP")
                .HasMaxLength(70)
                .IsUnicode(false);

            builder.Property(e => e.DescripcionCaracteristica)
                .HasColumnName("DSC_CARACTERISTICA")
                .HasMaxLength(300)
                .IsUnicode(true);

            builder.Property(e => e.Activo)
                .HasColumnName("FLAG_ACTIVO")
                .HasMaxLength(1)
                .IsUnicode(false);
        }
    }
}
