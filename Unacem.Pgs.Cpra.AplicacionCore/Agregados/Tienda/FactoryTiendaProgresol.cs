using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
    public class FactoryTiendaProgresol : Entidad, IRaizAgregado
    {
        public static TiendaProgresol CrearTiendaProgresol(TiendaDto pTiendaProgresol)
        {
            var nuevaTiendaProgresol = new TiendaProgresol(pTiendaProgresol.DscCodLocalSap, pTiendaProgresol.DscFotoAvatar, pTiendaProgresol.DscImagenAvatar, pTiendaProgresol.DscHorarioAtencion, pTiendaProgresol.DscCelular, pTiendaProgresol.DscCelularOpcional, pTiendaProgresol.DscNegocio,
                pTiendaProgresol.DscNombreComercialCorto,DateTime.Now,pTiendaProgresol.DscUsuarioCreacion);

            //nuevaTiendaProgresol.EstablecerHorarioAtencion(pTiendaProgresol.TiendaHorarioAtencion.CodTiendaProgresol, pTiendaProgresol.TiendaHorarioAtencion.CodRangoDiaAtencion,
            //    pTiendaProgresol.TiendaHorarioAtencion.CodHoraInicio,
            //    pTiendaProgresol.TiendaHorarioAtencion.CodHoraFin);

            //nuevaTiendaProgresol.GenerarNuevaIdentidad();
            nuevaTiendaProgresol.Activar();
            return nuevaTiendaProgresol;
            //return null;
        }
    }
}
