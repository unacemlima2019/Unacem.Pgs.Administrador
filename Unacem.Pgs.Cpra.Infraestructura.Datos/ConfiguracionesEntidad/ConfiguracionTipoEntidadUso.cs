using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Materiales;
using Unacem.Pgs.Cpra.Infraestructura.Datos;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    class ConfiguracionTipoEntidadUso : IEntityTypeConfiguration<Uso>
    {
        public void Configure(EntityTypeBuilder<Uso> builder)
        {
            builder.ToTable("PGSTB_USO", ProgresolContexto.DEFAULT_SCHEMA);

            builder.HasKey(e => e.Id)
                .HasName("PK_USO");

            builder.Property(e => e.Id).HasColumnName("COD_USO");

            builder.Property(e => e.CodigoUsoSap)
                .HasColumnName("COD_USO_SAP")
                .HasMaxLength(70)
                .IsUnicode(false);

            builder.Property(e => e.DescripcionUso)
                .HasColumnName("DSC_USO")
                .HasMaxLength(300)
                .IsUnicode(true);

            builder.Property(e => e.Activo)
                .HasColumnName("FLAG_ACTIVO")
                .HasMaxLength(1)
                .IsUnicode(false);
        }
    }
}
