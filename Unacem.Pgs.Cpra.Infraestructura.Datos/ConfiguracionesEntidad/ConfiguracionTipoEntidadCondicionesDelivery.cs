using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    public class ConfiguracionTipoEntidadCondicionesDelivery: IEntityTypeConfiguration<CondicionesDelivery>
    {
        public void Configure(EntityTypeBuilder<CondicionesDelivery> builder)
        {

            builder.HasKey(e => e.CodCondicionDelivery)
                    .HasName("PK_tblCondicionesDelivery");

            builder.ToTable("PGSTB_CONDICIONES_DELIVERY");

            builder.Property(e => e.CodCondicionDelivery).HasColumnName("COD_CONDICION_DELIVERY");

            builder.Property(e => e.DscActivo)
                    .HasColumnName("DSC_ACTIVO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

            builder.Property(e => e.DscCondicionDelivery)
                    .HasColumnName("DSC_CONDICION_DELIVERY")
                    .HasMaxLength(100)
                    .IsUnicode(false);

            builder.Property(e => e.Defecto)
                    .HasColumnName("DSC_DEFECTO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

        }
    }
}
