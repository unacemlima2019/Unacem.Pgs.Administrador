using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Infraestructura.Log
{
    public interface ILogFactory
    {
        ILog Crear();
    }
}
