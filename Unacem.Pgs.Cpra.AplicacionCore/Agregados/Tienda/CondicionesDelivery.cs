using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda
{
    public class CondicionesDelivery : IRaizAgregado
    {
        public CondicionesDelivery()
        {
            TiendaCondicionDelivery = new HashSet<TiendaCondicionDelivery>();
        }

        public int CodCondicionDelivery { get; set; }
        public string DscCondicionDelivery { get; set; }
        public string DscActivo { get; set; }
        public string Defecto { get; set; }
        public virtual ICollection<TiendaCondicionDelivery> TiendaCondicionDelivery { get; set; }
    }
}
