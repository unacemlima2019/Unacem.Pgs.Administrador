using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Infraestructura.Log
{
    public static class LogFactory
    {
        static ILogFactory _actualLogFactory = null;

        public static void EstablecerActual(ILogFactory logFactory)
        {
            _actualLogFactory = logFactory;
        }

        public static ILog CrearLog()
        {
            return (_actualLogFactory != null) ? _actualLogFactory.Crear() : null;
        }
    }
}
