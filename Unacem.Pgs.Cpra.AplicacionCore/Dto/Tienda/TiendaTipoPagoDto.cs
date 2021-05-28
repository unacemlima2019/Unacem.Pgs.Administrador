using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda
{
    public class TiendaTipoPagoDto
    {
        public int CodTiendaTipoPago { get; set; }
        public int? CodTiendaProgresol { get; set; }
        public int? CodTipoPago { get; set; }

        public virtual TiendaDto CodTiendaProgresolNavigation { get; set; }
        public virtual TipoPagoDto CodTipoPagoNavigation { get; set; }
    }
}
