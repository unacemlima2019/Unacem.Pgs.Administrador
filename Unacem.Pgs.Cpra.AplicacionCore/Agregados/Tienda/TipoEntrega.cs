using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
   public class TipoEntrega : Entidad, IRaizAgregado
    {
        public TipoEntrega()
        {
            TiendaTipoEntrega = new HashSet<TiendaTipoEntrega>();
        }

        public int CodTipoEntrega { get; set; }
        public string DscTipo { get; set; }
        public string DscRutaLogo { get; set; }
        public string Defecto { get; set; }
        public virtual ICollection<TiendaTipoEntrega> TiendaTipoEntrega { get; set; }
    }
}
