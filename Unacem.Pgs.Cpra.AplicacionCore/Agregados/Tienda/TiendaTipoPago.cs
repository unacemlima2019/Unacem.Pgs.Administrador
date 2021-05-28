using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Recursos;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.AplicacionCore.Excepciones;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
    public class TiendaTipoPago : IRaizAgregado
    {
        public int CodTiendaTipoPago { get; set; }
        public virtual TiendaProgresol CodTiendaProgresolNavigation { get; set; }
        public virtual TipoPago CodTipoPagoNavigation { get; set; }

        public int CodTipoPago => _CodTipoPago;
        private int _CodTipoPago;

        public int CodTiendaProgresol => _CodTiendaProgresol;
        private int _CodTiendaProgresol;
        public TiendaTipoPago() { }
        public TiendaTipoPago(int pCodTipoPago, int pCodTiendaProgresol)
        {
            //if (pCodigoCompra == Guid.Empty)
            //    throw new ProgresolExcepcionDominio(Mensajes.dominio_validacion_CodigoCompraDeCompraDetalleVacio);

            //Poner mensaje
            if (pCodTipoPago <= 0)
                throw new ProgresolExcepcionDominio(Mensajes.validacion_TipoPagoMenorIgualCero);

            //if (pCodTiendaProgresol <= 0)
            //    throw new ProgresolExcepcionDominio(Mensajes.dominio_validacion_CantidadDeCompraDetalleMenorIgualCero);

            _CodTipoPago = pCodTipoPago;
            _CodTiendaProgresol = pCodTiendaProgresol;

        }
    }
}
