using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda
{
    public class TiendaTiempoEntregaDto
    {
        public int CodTiendaTiempoEntrega { get; set; }
        public int? CodTiendaProgresol { get; set; }
        public int? CodTiempoEntrega { get; set; }

        public virtual TiempoEntregaDto CodTiempoEntregaNavigation { get; set; }
        public virtual TiendaDto CodTiendaProgresolNavigation { get; set; }
    }
}
