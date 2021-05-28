using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda
{
    public class TiempoEntregaDto
    {
        //public TiempoEntregaDto()
        //{
        //    TiendaTiempoEntrega = new HashSet<TiempoEntregaDto>();
        //}

        public int CodTiempoEntrega { get; set; }
        public string DscTiempoEntrega { get; set; }
        public string DscActivo { get; set; }

        //public virtual ICollection<TiempoEntregaDto> TiendaTiempoEntrega { get; set; }
    }
}
