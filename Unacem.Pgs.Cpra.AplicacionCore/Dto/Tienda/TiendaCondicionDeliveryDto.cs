using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda
{
    public class TiendaCondicionDeliveryDto
    {
        public int CodTiendaCondDelivery { get; set; }
        public int? CodCondicionDelivery { get; set; }
        public int? CodTiendaProgresol { get; set; }
        public string DscMontoMin { get; set; }

        public virtual CondicionesDeliveryDto CodCondicionDeliveryNavigation { get; set; }
        public virtual TiendaDto CodTiendaProgresolNavigation { get; set; }
    }
}
