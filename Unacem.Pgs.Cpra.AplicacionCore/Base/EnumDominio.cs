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

    public struct EnumEstadoDocumento
    {
        public const int PENDIENTE = 6;
        public const int EMITIDO = 7;
        public const int COTIZADO = 8;
        public const int ENTREGADO = 9;
        public const int ANULADO = 10;
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

    public struct EnumCategoriaMaterial
    {
        public const string CategoriaCemento = "CEMENTO";
    }

    public struct EnumValidaDocumento
    {
        public const int CantidadDigitosRuc = 11;
    }

    public struct EnumTipoProveedor
    {
        public const string ProveedorExterno = "PRVEXT";
        public const string ProveedorProgresol = "PRVPGS";
        public const string ProveedorSubDistribuidor = "PRVSUBDSTR";
    }

    public struct EnumCodCategoriaMaterial
    {
        public const string Cemento = "42B277EA-4649-4771-B859-AA07AB0D3D75";
    }

    public struct EnumCodUnidadMedidaMaterial
    {
        public const string Bolsa = "64401A49-2291-4810-ADE8-3BD01C37D42F";
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
