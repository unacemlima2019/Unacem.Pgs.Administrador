using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Materiales;
using Unacem.Pgs.Cpra.Infraestructura.Datos;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    class ConfiguracionTipoEntidadCaracteristicaMaterial : IEntityTypeConfiguration<CaracteristicaMaterial>
    {
        public void Configure(EntityTypeBuilder<CaracteristicaMaterial> builder)
        {
            builder.ToTable("PGSTB_CARACTERISTICA_MATERIAL", ProgresolContexto.DEFAULT_SCHEMA);

            builder.HasKey(e => e.Id)
                .HasName("PK_CARACTERISTICA_MATERIAL");

            builder.Property(e => e.Id).HasColumnName("COD_CARACTERISTICA_MATERIAL");

            builder.Property(e => e.CodigoCaracteristica).HasColumnName("COD_CARACTERISTICA").IsRequired();

            builder.Property(e => e.DetalleCaracteristicaMaterial)
                .HasColumnName("DSC_DETALLE_CARACTERISTICA_MATERIAL")
                .HasMaxLength(300)
                .IsUnicode(true);

            builder.Property(e => e.Activo)
                .HasColumnName("FLAG_ACTIVO")
                .HasMaxLength(1)
                .IsUnicode(false);

            //CLAVES
            builder.Property(e => e.CodigoMaterial)
                .HasColumnName("COD_MATERIAL");

            //RELACIONES FORANEAS
            builder.HasOne<Material>()
                .WithMany()
                .IsRequired(true)
                .HasForeignKey("CodigoMaterial")
                .HasConstraintName("FK_PGSTB_CARACTERISTICA_MATERIAL_PGSTB_MATERIAL")
                .OnDelete(DeleteBehavior.NoAction);

            //RELACION ROOT (Desde agregado)
            builder.HasOne(d => d.Caracteristica)
                .WithMany(p => p.CaracteristicaMateriales)
                .HasForeignKey(d => d.CodigoCaracteristica)
                .HasConstraintName("FK_PGSTB_CARACTERISTICA_MATERIAL_PGSTB_CARACTERISTICA");
        }
    }
}
