using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
   public class TiendaProductoDestacados : IRaizAgregado
    {
        public TiendaProductoDestacados(int codTiendaProgresol, int codProductoDestacado)
        {
            _CodTiendaProgresol = codTiendaProgresol;
            _CodProductoDestacado = codProductoDestacado;
        }
        public TiendaProductoDestacados() { }

        public int CodTiendaProductoDestacado { get; set; }

        public int CodTiendaProgresol => _CodTiendaProgresol;
        private int _CodTiendaProgresol;

        public int CodProductoDestacado => _CodProductoDestacado;
        private int _CodProductoDestacado;


        //public int CodTiendaProgresol { get; set; }
        //public int CodProductoDestacado { get; set; }

        public virtual ProductoDestacados CodProductoDestacadoNavigation { get; set; }
        public virtual TiendaProgresol CodTiendaProgresolNavigation { get; set; }
    }
}
