using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Materiales;
using Unacem.Pgs.Cpra.Infraestructura.Datos;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    class ConfiguracionTipoEntidadUsoMaterial : IEntityTypeConfiguration<UsoMaterial>
    {
        public void Configure(EntityTypeBuilder<UsoMaterial> builder)
        {
            builder.ToTable("PGSTB_USO_MATERIAL", ProgresolContexto.DEFAULT_SCHEMA);

            builder.HasKey(e => e.Id)
                .HasName("PK_USO_MATERIAL");

            builder.Property(e => e.Id).HasColumnName("COD_USO_MATERIAL");

            builder.Property(e => e.CodigoUso).HasColumnName("COD_USO").IsRequired();

            builder.Property(e => e.DetalleUsoMaterial)
                .HasColumnName("DSC_DETALLE_USO_MATERIAL")
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
                .HasConstraintName("FK_PGSTB_USO_MATERIAL_PGSTB_MATERIAL")
                .OnDelete(DeleteBehavior.NoAction);

            //RELACION ROOT (Desde agregado)
            builder.HasOne(d => d.Uso)
                .WithMany(p => p.UsoMateriales)
                .HasForeignKey(d => d.CodigoUso)
                .HasConstraintName("FK_PGSTB_USO_MATERIAL_PGSTB_USO");
        }
    }
}
