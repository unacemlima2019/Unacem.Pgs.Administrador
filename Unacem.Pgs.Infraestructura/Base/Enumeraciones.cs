using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Infraestructura.Base
{
    public struct EnumLogNivel
    {
        public const int Trace = 0;
        public const int Debug = 1;
        public const int Information = 2;
        public const int Warning = 3;
        public const int Error = 4;
        public const int Critical = 5;
    }

    public struct EnumCodigoAplicacion
    {
        public const string PgsAppWebPublico = "PGS-AWPub";
        public const string PgsWebApiPublico = "PGS-WAPub";
        public const string PgsMsVentas = "PGS-MsVta";
        public const string PgsMsAdminTiendas = "PGS-MsAdminTienda";
    }

    public struct EnumUsuarioDefault
    {
        public const string PgsPublico = "UsrProgre";
    }

    public struct EnumCodigoErrorDefault
    {
        public const int Debug = 10;
        public const int DebugSinExcepcion = 11;
        public const int DebugConExcepcion = 12;
        public const int FatalSinExcepcion = 13;
        public const int FatalConExcepcion = 14;
        public const int LogErrorSinExcepcion = 15;
        public const int LogInfo = 16;
        public const int LogWarning = 17;
    }
}
