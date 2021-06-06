using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Infraestructura.Log;

namespace Unacem.Pgs.Cpra.Infraestructura.Net.Log
{
    public class LogOrigenTrazaFactory : ILogFactory
    {
        public ILog Crear()
        {
            return new LogOrigenTrazaEventosWindows();
        }
    }
}
