using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda
{
    public class TiendaTipoEntregaDto
    {
        public int CodTipoEntregaTienda { get; set; }
        public int? CodTipoEntrega { get; set; }
        public int? CodTiendaProgresol { get; set; }

        public virtual TiendaDto CodTiendaProgresolNavigation { get; set; }
        public virtual TipoEntregaDto CodTipoEntregaNavigation { get; set; }
    }
}
