using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
    public class TiendaTipoEntrega: Entidad
    {
        public int CodTipoEntregaTienda { get; set; }
        public int? CodTipoEntrega { get; set; }
        public int? CodTiendaProgresol { get; set; }

    }
}
