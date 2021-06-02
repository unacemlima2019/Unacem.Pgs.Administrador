using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad
{
    public class ConfiguracionTipoEntidadTiendaHorarioAtencion : IEntityTypeConfiguration<TiendaHorarioAtencion>
    {
        public void Configure(EntityTypeBuilder<TiendaHorarioAtencion> builder)
        {

            builder.HasKey(e => e.CodTiendaHorarioAtencion)
                    .HasName("PK_PGSTB_TIENDA_HORARIO_ATENCION_1");

            builder.ToTable("PGSTB_TIENDA_HORARIO_ATENCION");

            //builder.HasIndex(e => new { e.CodTiendaProgresol, e.CodRangoDiaAtencion, e.CodHoraInicio, e.CodHoraFin })
            //        .HasName("IX_TIENDA_PROGRESOL");

            builder.Property(e => e.CodTiendaHorarioAtencion).HasColumnName("COD_TIENDA_HORARIO_ATENCION");

            builder.Property(e => e.CodHoraFin).HasColumnName("COD_HORA_FIN");

            builder.Property(e => e.CodHoraInicio).HasColumnName("COD_HORA_INICIO");

            builder.Property(e => e.CodRangoDiaAtencion).HasColumnName("COD_RANGO_DIA_ATENCION");

            builder.Property(e => e.CodTiendaProgresol).HasColumnName("COD_TIENDA_PROGRESOL");

            builder.HasOne(d => d.CodRangoDiaAtencionNavigation)
                    .WithMany(p => p.TiendaHorarioAtencion)
                    .HasForeignKey(d => d.CodRangoDiaAtencion)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PGSTB_TIE__COD_R__710B0E66");

            builder.HasOne(d => d.CodTiendaProgresolNavigation)
                    .WithMany(p => p.TiendaHorarioAtencion)
                    .HasForeignKey(d => d.CodTiendaProgresol)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PGSTB_TIE__COD_T__71FF329F");
          


        }
    }
}
