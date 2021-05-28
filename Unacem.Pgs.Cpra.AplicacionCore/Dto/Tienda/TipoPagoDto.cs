using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda
{
    public class TipoPagoDto
    {
        //public TipoPagoDto()
        //{
        //    TiendaTipoPago = new HashSet<TipoPagoDto>();
        //}

        public int CodTipoPago { get; set; }
        public string DscTipoPago { get; set; }
        public string DscRutaLogo { get; set; }
        public string DscActivo { get; set; }

        //public virtual ICollection<TipoPagoDto> TiendaTipoPago { get; set; }
    }
}
