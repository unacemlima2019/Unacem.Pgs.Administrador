using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;

namespace Unacem.Pgs.Cpra.Infraestructura.Datos.ConfiguracionesEntidad
{
    class ConfiguracionTipoEntidadProgresol : IEntityTypeConfiguration<Progresol>
    {
        public void Configure(EntityTypeBuilder<Progresol> builder)
        {
            builder.ToTable("PGSTB_TEMP_FUN_CLIENTESPS_SAP");

            builder.HasKey(e => e.CodigoLocalProgresolSap)
                .HasName("PK_TEMP_FUN_CLIENTESPS_SAP_X_LOCAL");

            builder.Property(e => e.CodigoLocalProgresolSap).HasColumnName("COD_PDV")
                .HasMaxLength(10)
                .IsUnicode(false);
            //builder.HasKey(e => e.Id)
            //    .HasName("PK_TEMP_FUN_CLIENTESPS_SAP");
            //builder.Property(e => e.Id).HasColumnName("COD_PROGRESOL");


            builder.Property(e => e.CorrelativoCliente).HasColumnName("COD_CLIENTEPS_SAP")
                                                        .UseIdentityColumn(1, 1); 

            builder.Property(e => e.CodigoProgresolHijoSap)
                .HasColumnName("COD_HIJO")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.CodigoProgresolSap)
                .HasColumnName("COD_PADRE")
                .HasMaxLength(10)
                .IsUnicode(false);

            //builder.Property(e => e.CodigoLocalProgresolSap)
            //    .HasColumnName("COD_PDV")
            //    .HasMaxLength(10)
            //    .IsUnicode(false);

            builder.Property(e => e.CelularDueño)
                .HasColumnName("DSC_CELULAR_DUENO")
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.Departamento)
                .HasColumnName("DSC_DEPARTAMENTO")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Direccion)
                .HasColumnName("DSC_DIRECCION")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Distrito)
                .HasColumnName("DSC_DISTRITO")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.FlagTienda)
                .HasColumnName("DSC_FLAG_TIENDA")
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            builder.Property(e => e.HorarioAtencion)
                .HasColumnName("DSC_HORARIO_ATENCION")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Latitud)
                .HasColumnName("DSC_LATITUD")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.LogoTienda)
                .HasColumnName("DSC_LOGO_TIENDA")
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.Longitud)
                .HasColumnName("DSC_LONGITUD")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.NombreComercial)
                .HasColumnName("DSC_NOMBRE_COMERCIAL")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Provincia)
                .HasColumnName("DSC_PROVINCIA")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.NombreORazonSocialProgresol)
                .HasColumnName("DSC_RAZON_SOCIAL")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.TipoProgresol)
                .HasColumnName("DSC_TIPO_PROGRESOL")
                .HasMaxLength(20)
                .IsUnicode(false);

            //builder.Property(e => e.EsActualizableSaldosCuota)
            //    .HasColumnName("FLAG_ACTUALIZA_SALDO_CUOTA");

            //builder.Property(e => e.Activo)
            //    .HasColumnName("FLAG_ACTIVO")
            //    .HasMaxLength(1)
            //    .IsUnicode(false);

        }
    }
}
