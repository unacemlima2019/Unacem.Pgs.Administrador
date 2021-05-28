using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Cpra.AplicacionCore.Base
{
    public struct EnumEstadoTransaccion
    {
        public const int PENDIENTE = 1;
        public const int COTIZADA = 2;
        public const int PEDIDA = 3;
        public const int VENDIDA = 4;
        public const int ANULADA = 5;
    }
    public struct EnumActivacion
    {
        public const string Activado = "S";
        public const string Desactivado = "N";
    }

    public struct EnumActivacionLocalProgesol
    {
        public const string Activado = "X";
        public const string Desactivado = "";
    }

    public struct EnumRolTipoProgresol
    {
        public const string ProgresolUno = "Progresol 1.0";
        public const string ProgresolDos = "Progresol 2.0";
    }

    //public struct EnumTipoDocumento
    //{
    //    public const string COTIZACION = "CTZ";
    //    public const string PEDIDO = "PED";
    //    public const string VENTA = "VTA";
    //}
}
