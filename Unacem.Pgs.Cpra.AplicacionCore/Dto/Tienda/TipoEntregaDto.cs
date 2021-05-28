using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda
{
   public class TipoEntregaDto
    {
        public TipoEntregaDto()
        {
            TiendaTipoEntrega = new HashSet<TiendaTipoEntregaDto>();
        }

        public int CodTipoEntrega { get; set; }
        public string DscTipo { get; set; }
        public string DscRutaLogo { get; set; }

        public virtual ICollection<TiendaTipoEntregaDto> TiendaTipoEntrega { get; set; }
    }
}
