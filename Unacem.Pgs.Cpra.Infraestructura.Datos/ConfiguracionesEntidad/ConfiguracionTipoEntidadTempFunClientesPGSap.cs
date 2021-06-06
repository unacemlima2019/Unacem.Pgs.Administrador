using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Progresol;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    public class ConfiguracionTipoEntidadTempFunClientesPGSap :
        IEntityTypeConfiguration<TempFunClientesPGSap>
    {
        public void Configure(EntityTypeBuilder<TempFunClientesPGSap> builder)
        {
            builder.HasKey(e => e.CodPdv)
                    .HasName("PK_TEMP_FUN_CLIENTESPS_SAP_X_LOCAL");

            builder.ToTable("PGSTB_TEMP_FUN_CLIENTESPS_SAP");

            builder.Property(e => e.CodPdv)
                .HasColumnName("COD_PDV")
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.CodClientepsSap)
                .HasColumnName("COD_CLIENTEPS_SAP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CodHijo)
                .HasColumnName("COD_HIJO")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.CodPadre)
                .HasColumnName("COD_PADRE")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.CodSubTerritorio)
                .HasColumnName("COD_SUB_TERRITORIO")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.CodTerritorio)
                .HasColumnName("COD_TERRITORIO")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.CodZona)
                .HasColumnName("COD_ZONA")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.DscCelularDueno)
                .HasColumnName("DSC_CELULAR_DUENO")
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.DscDepartamento)
                .HasColumnName("DSC_DEPARTAMENTO")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.DscDireccion)
                .HasColumnName("DSC_DIRECCION")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.DscDistrito)
                .HasColumnName("DSC_DISTRITO")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.DscFlagTienda)
                .HasColumnName("DSC_FLAG_TIENDA")
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            builder.Property(e => e.DscHorarioAtencion)
                .HasColumnName("DSC_HORARIO_ATENCION")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DscLatitud)
                .HasColumnName("DSC_LATITUD")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DscLogoTienda)
                .HasColumnName("DSC_LOGO_TIENDA")
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.DscLongitud)
                .HasColumnName("DSC_LONGITUD")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DscNombreComercial)
                .HasColumnName("DSC_NOMBRE_COMERCIAL")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.DscProvincia)
                .HasColumnName("DSC_PROVINCIA")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.DscRazonSocial)
                .HasColumnName("DSC_RAZON_SOCIAL")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.DscRucCliente)
                .HasColumnName("DSC_RUC_CLIENTE")
                .HasMaxLength(11)
                .IsUnicode(false);

            builder.Property(e => e.DscSubTerritorio)
                .HasColumnName("DSC_SUB_TERRITORIO")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.DscTerritorio)
                .HasColumnName("DSC_TERRITORIO")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.DscTipoProgresol)
                .HasColumnName("DSC_TIPO_PROGRESOL")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.DscZona)
                .HasColumnName("DSC_ZONA")
                .HasMaxLength(200)
                .IsUnicode(false);
        }
    }
}
