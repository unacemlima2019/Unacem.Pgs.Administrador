using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
   public class ProductoDestacados :  IRaizAgregado
    {
        public ProductoDestacados()
        {
            TiendaProductosDestacado = new HashSet<TiendaProductoDestacados>();
        }

        public int CodProductoDestacado { get; set; }
        public string DscNombre { get; set; }
        public string DscRuta { get; set; }
        public DateTime? FchCreacion { get; set; }
        public DateTime? FchActualizacion { get; set; }
        public string DscActivo { get; set; }
        public string DscCategoria { get; set; }

        public virtual ICollection<TiendaProductoDestacados> TiendaProductosDestacado { get; set; }
    }
}
