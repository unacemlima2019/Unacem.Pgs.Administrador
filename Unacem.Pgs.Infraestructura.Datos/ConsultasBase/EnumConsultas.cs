using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Infraestructura.Datos.ConsultasBase
{
    public struct EnumResultadoConsulta
    {
        public const int OK = 7;
        public const int ERROR = 6;
        public const int SINRESULTADO = 8;
        public const string DESCRIPCIONOK = "CORRECTO";
        public const string DESCRIPCIONERROR = "INCORRECTO";
        public const string DESCRIPCIONSINRESULTADO = "SIN RESULTADO";
    }

}
