using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
    public class TiempoEntrega : IRaizAgregado
    {
        public TiempoEntrega()
        {
            TiendaTiempoEntrega = new HashSet<TiendaTiempoEntrega>();
        }

        public int CodTiempoEntrega { get; set; }
        public string DscTiempoEntrega { get; set; }
        public string DscActivo { get; set; }

        public virtual ICollection<TiendaTiempoEntrega> TiendaTiempoEntrega { get; set; }
    }
}
