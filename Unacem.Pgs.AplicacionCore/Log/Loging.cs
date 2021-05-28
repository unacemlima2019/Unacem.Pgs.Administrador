using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.AplicacionCore.Log
{
    public class Loging : IRaizAgregado
    {
        public string CodigoAplicacion => _codigoAplicacion;
        private string _codigoAplicacion;

        public string NumeroTicket => _numeroTicket;
        private string _numeroTicket;

        public string CodigoUsuario => _codigoUsuario;
        private string _codigoUsuario;

        public int CodigoError => _codigoError;
        private int _codigoError;

        public string DescripcionError => _descripcionError;
        private string _descripcionError;

        public DateTime FechaError => _fechaError;
        private DateTime _fechaError;

        public string DetalleError => _detalleError;
        private string _detalleError;

        public Loging(string pCodigoAplicacion, string pNumeroTicket, string pCodigoUsuario,
                    int pCodigoError, string pDescripcionError, DateTime pFechaError, string pDetalleError)
        {
            _codigoAplicacion = pCodigoAplicacion;
            _numeroTicket = pNumeroTicket;
            _codigoUsuario = pCodigoUsuario;
            _codigoError = pCodigoError;
            _descripcionError = pDescripcionError;
            _fechaError = pFechaError;
            _detalleError = pDetalleError;
        }
    }
}
