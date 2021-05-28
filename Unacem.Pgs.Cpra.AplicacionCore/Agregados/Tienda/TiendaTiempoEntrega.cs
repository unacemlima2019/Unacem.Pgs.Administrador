using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Recursos;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.AplicacionCore.Excepciones;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
    public class TiendaTiempoEntrega : IRaizAgregado
    {
        public int CodTiendaTiempoEntrega { get; set; }
        //public int? CodTiendaProgresol { get; set; }
        //public int? CodTiempoEntrega { get; set; }

        public int CodTiendaProgresol=>_CodTiendaProgresol;
        private int _CodTiendaProgresol;

        public int CodTiempoEntrega => _CodTiempoEntrega;
        private int _CodTiempoEntrega;

        public TiendaTiempoEntrega() { }

        public TiendaTiempoEntrega(int pCodTiendaProgresol, int pCodTiempoEntrega)
        {
            //Poner mensaje
            if (pCodTiempoEntrega <= 0)
                throw new ProgresolExcepcionDominio(Mensajes.validacion_TiempoEntregaMenorIgualCero);

            _CodTiempoEntrega = pCodTiempoEntrega;
            _CodTiendaProgresol = pCodTiendaProgresol;

        }


        public virtual TiempoEntrega CodTiempoEntregaNavigation { get; set; }
        public virtual TiendaProgresol CodTiendaProgresolNavigation { get; set; }
    }
}
