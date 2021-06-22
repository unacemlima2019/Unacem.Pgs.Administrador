using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Admin.AplicacionCore.Dto.Tienda
{
   public class TiendaHorarioAtencionDto
    {
        public int CodTiendaHorarioAtencion { get; set; }
        public int CodTiendaProgresol { get; set; }
        public int CodRangoDiaAtencion { get; set; }
        public int CodHoraInicio { get; set; }
        public int CodHoraFin { get; set; }
        public string RangoDiaAtencionDescripcion { get; set; }
    }
}
