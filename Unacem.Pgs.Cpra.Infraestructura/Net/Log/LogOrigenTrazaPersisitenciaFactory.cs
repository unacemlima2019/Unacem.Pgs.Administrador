using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.AplicacionCore.Log;
using Unacem.Pgs.Cpra.Infraestructura.Base;
using Unacem.Pgs.Infraestructura.Log;

namespace Unacem.Pgs.Cpra.Infraestructura.Net.Log
{
    public class LogOrigenTrazaPersisitenciaFactory : ILogFactory
    {
        private readonly IRepositorioLoging _IRepositorioLoging;
        private ConfiguracionAplicacion _configuracionAplicacion;
        public LogOrigenTrazaPersisitenciaFactory(IRepositorioLoging pIRepositorioLog, ConfiguracionAplicacion pConfiguracionAplicacion)
        {
            _IRepositorioLoging = pIRepositorioLog;
            _configuracionAplicacion = pConfiguracionAplicacion;
        }

        public ILog Crear()
        {
            return new LogOrigenTrazaBaseDatos(_IRepositorioLoging, _configuracionAplicacion);
        }
    }
}
