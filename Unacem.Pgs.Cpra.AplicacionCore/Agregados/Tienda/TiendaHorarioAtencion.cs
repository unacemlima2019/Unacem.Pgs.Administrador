using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
    public class TiendaHorarioAtencion: IRaizAgregado
    {
        public int CodTiendaHorarioAtencion { get; set; }
        public TiendaHorarioAtencion(int codTiendaProgresol, int codRangoDiaAtencion, int codHoraInicio, int codHoraFin)
        {
            _CodTiendaProgresol = codTiendaProgresol;
            _CodRangoDiaAtencion = codRangoDiaAtencion;
            _CodHoraInicio = codHoraInicio;
            _CodHoraFin = codHoraFin;
        }
        public TiendaHorarioAtencion() { }

        public int CodTiendaProgresol => _CodTiendaProgresol;
        private int _CodTiendaProgresol;

        public int CodRangoDiaAtencion => _CodRangoDiaAtencion;
        private int _CodRangoDiaAtencion;

        public int CodHoraInicio => _CodHoraInicio;
        private int _CodHoraInicio;

        public int CodHoraFin => _CodHoraFin;
        private int _CodHoraFin;

        //public int CodRangoDiaAtencion => _CodRangoDiaAtencion;
        //private int _CodRangoDiaAtencion;

        //public int CodRangoDiaAtencion { get; set; }


        //public int CodTiendaProgresol { get; set; }
        //public int CodRangoDiaAtencion { get; set; }
        //public int CodHoraInicio { get; set; }
        //public int CodHoraFin { get; set; }

        public virtual RangoDiaAtencion CodRangoDiaAtencionNavigation { get; set; }
        public virtual TiendaProgresol CodTiendaProgresolNavigation { get; set; }
    }
}
