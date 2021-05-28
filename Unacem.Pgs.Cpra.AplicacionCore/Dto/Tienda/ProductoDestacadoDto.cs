using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda
{
   public class ProductoDestacadoDto
    {
        //public ProductoDestacadoDto()
        //{
        //    TiendaProductoDestacado = new HashSet<ProductoDestacadoDto>();
        //}

        public int CodProductoDestacado { get; set; }
        public string DscNombre { get; set; }
        public string DscRuta { get; set; }
        public DateTime? FchCreacion { get; set; }
        public DateTime? FchActualizacion { get; set; }
        public string DscActivo { get; set; }
        public string DscCategoria { get; set; }

        //public virtual ICollection<ProductoDestacadoDto> TiendaProductoDestacado { get; set; }
    }
}
