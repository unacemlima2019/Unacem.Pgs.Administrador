using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
   public class TiendaCondicionDelivery: IRaizAgregado
    {
        public int CodTiendaCondDelivery { get; set; }
        public string DscMontoMin => _DscMontoMin;
        private string _DscMontoMin;

        public int CodCondicionDelivery => _CodCondicionDelivery;
        private int _CodCondicionDelivery;


        public int CodTiendaProgresol => _CodTiendaProgresol;
        private int _CodTiendaProgresol;

        public virtual CondicionesDelivery CodCondicionDeliveryNavigation { get; set; }
        public virtual TiendaProgresol CodTiendaProgresolNavigation { get; set; }

        public TiendaCondicionDelivery() { }

        public TiendaCondicionDelivery(int pCodCondicionDelivery,int pCodProgresol,string pMontoMinimo)
        {
            _CodCondicionDelivery = pCodCondicionDelivery;
            _CodTiendaProgresol = pCodProgresol;
            _DscMontoMin = pMontoMinimo;
        }
    }
}
