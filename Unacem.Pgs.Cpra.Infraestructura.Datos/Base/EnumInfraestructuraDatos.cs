using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.Base
{
    public struct EnumEstadoDocumento
    {
        public const int Anulado = 10;
    }

    public struct EnumActividadEstado
    {
        public const string Activo = "S";
        public const string Inactivo = "N";
    }

    public struct EnumActivacionLocalProgesol
    {
        public const string Activado = "X";
        public const string Desactivado = "";
    }
}
