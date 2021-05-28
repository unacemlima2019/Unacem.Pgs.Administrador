using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;
using Unacem.Pgs.Cpra.Infraestructura.Datos;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    public class ConfiguracionTipoEntidadTienda: IEntityTypeConfiguration<TiendaProgresol>
    {
        public void Configure(EntityTypeBuilder<TiendaProgresol> builder)
        {

            builder.ToTable("PGSTB_TIENDA_PROGRESOL", ProgresolContexto.DEFAULT_SCHEMA);

            builder.HasKey(e => e.CodTiendaProgresol)
                    .HasName("PK_tblTiendaProgresol");

            //builder.ToTable("PGSTB_TIENDA_PROGRESOL");
            //builder.Ignore(i => i.Id);
            builder.Property(e => e.CodTiendaProgresol).HasColumnName("COD_TIENDA_PROGRESOL");

            builder.Property(e => e.Activo)
                    .HasColumnName("DSC_ACTIVO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

            builder.Property(e => e.Celular)
                    .HasColumnName("DSC_CELULAR")
                    .HasMaxLength(15)
                    .IsUnicode(false);

            builder.Property(e => e.CelularOpcional)
                    .HasColumnName("DSC_CELULAR_OPCIONAL")
                    .HasMaxLength(15)
                    .IsUnicode(false);

            builder.Property(e => e.CodLocalSap)
                    .HasColumnName("DSC_COD_LOCAL_SAP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

            builder.Property(e => e.FechaCreacion)
                    .HasColumnName("DSC_FECHA_CREACION")
                    .HasColumnType("datetime");

            builder.Property(e => e.FechaModificacion)
                    .HasColumnName("DSC_FECHA_MODIFICACION")
                    .HasColumnType("datetime");

            builder.Property(e => e.FotoAvatar)
                    .HasColumnName("DSC_FOTO_AVATAR")
                    .HasMaxLength(150)
                    .IsUnicode(false);

            builder.Property(e => e.HorarioAtencion)
                    .HasColumnName("DSC_HORARIO_ATENCION")
                    .HasMaxLength(300)
                    .IsUnicode(false);

            builder.Property(e => e.ImagenAvatar).HasColumnName("DSC_IMAGEN_AVATAR");

            builder.Property(e => e.Negocio)
                    .HasColumnName("DSC_NEGOCIO")
                    .HasMaxLength(300)
                    .IsUnicode(false);

            builder.Property(e => e.NombreComercialCorto)
                    .HasColumnName("DSC_NOMBRE_COMERCIAL_CORTO")
                    .HasMaxLength(120)
                    .IsUnicode(false);

            builder.Property(e => e.UsuarioCreacion)
                    .HasColumnName("DSC_USUARIO_CREACION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.UsuarioModificacion)
                    .HasColumnName("DSC_USUARIO_MODIFICACION")
                    .HasMaxLength(50)
                    .IsUnicode(false);




            //builder.HasKey(e => e.CodTiendaProgresol)
            //       .HasName("PK_tblTiendaProgresol");

            //builder.ToTable("PGSTB_TIENDA_PROGRESOL");

            //builder.HasIndex(e => new { e.CodTiendaProgresol, e.CodLocalSap })
            //    .HasName("IX_DSC_COD_LOCAL_SAP");

            //builder.Property(e => e.CodTiendaProgresol).HasColumnName("COD_TIENDA_PROGRESOL");

            //builder.Property(e => e.Activo)
            //    .HasColumnName("DSC_ACTIVO")
            //    .HasMaxLength(1)
            //    .IsUnicode(false)
            //    .IsFixedLength();

            //builder.Property(e => e.Celular)
            //    .HasColumnName("DSC_CELULAR")
            //    .HasMaxLength(15)
            //    .IsUnicode(false);

            //builder.Property(e => e.CelularOpcional)
            //    .HasColumnName("DSC_CELULAR_OPCIONAL")
            //    .HasMaxLength(15)
            //    .IsUnicode(false);

            //builder.Property(e => e.CodLocalSap)
            //    .HasColumnName("DSC_COD_LOCAL_SAP")
            //    .HasMaxLength(10)
            //    .IsUnicode(false);

            //builder.Property(e => e.FechaCreacion)
            //    .HasColumnName("DSC_FECHA_CREACION")
            //    .HasColumnType("datetime");

            //builder.Property(e => e.FechaModificacion)
            //    .HasColumnName("DSC_FECHA_MODIFICACION")
            //    .HasColumnType("datetime");

            //builder.Property(e => e.FotoAvatar)
            //    .HasColumnName("DSC_FOTO_AVATAR")
            //    .HasMaxLength(150)
            //    .IsUnicode(false);

            //builder.Property(e => e.HorarioAtencion)
            //    .HasColumnName("DSC_HORARIO_ATENCION")
            //    .HasMaxLength(300)
            //    .IsUnicode(false);

            //builder.Property(e => e.ImagenAvatar).HasColumnName("DSC_IMAGEN_AVATAR");

            //builder.Property(e => e.Negocio)
            //    .HasColumnName("DSC_NEGOCIO")
            //    .HasMaxLength(300)
            //    .IsUnicode(false);

            //builder.Property(e => e.NombreComercialCorto)
            //    .HasColumnName("DSC_NOMBRE_COMERCIAL_CORTO")
            //    .HasMaxLength(120)
            //    .IsUnicode(false);

            //builder.Property(e => e.UsuarioCreacion)
            //    .HasColumnName("DSC_USUARIO_CREACION")
            //    .HasMaxLength(50)
            //    .IsUnicode(false);

            //builder.Property(e => e.UsuarioModificacion)
            //    .HasColumnName("DSC_USUARIO_MODIFICACION")
            //    .HasMaxLength(50)
            //    .IsUnicode(false);

        }
    }
}
