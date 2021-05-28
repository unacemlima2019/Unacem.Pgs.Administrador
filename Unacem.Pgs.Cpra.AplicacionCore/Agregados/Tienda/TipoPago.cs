using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
    public class TipoPago : IRaizAgregado
    {
        public TipoPago()
        {
            TiendaTipoPago = new HashSet<TiendaTipoPago>();
        }

        public int CodTipoPago { get; set; }
        public string DscTipoPago { get; set; }
        public string DscRutaLogo { get; set; }
        public string DscActivo { get; set; }

        public virtual ICollection<TiendaTipoPago> TiendaTipoPago { get; set; }
    }
}
