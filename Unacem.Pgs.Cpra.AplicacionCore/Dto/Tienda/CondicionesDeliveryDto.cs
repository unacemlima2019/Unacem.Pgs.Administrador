using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda
{
    public class CondicionesDeliveryDto
    {
        //public CondicionesDeliveryDto()
        //{
        //    TiendaCondicionDelivery = new HashSet<TiendaCondicionDeliveryDto>();
        //}

        public int CodCondicionDelivery { get; set; }
        public string DscCondicionDelivery { get; set; }
        public string DscActivo { get; set; }
        public string DscMontoMinimo { get; set; }
        //public virtual ICollection<TiendaCondicionDeliveryDto> TiendaCondicionDelivery { get; set; }
    }
}
