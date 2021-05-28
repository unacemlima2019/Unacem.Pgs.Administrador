using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Cpra.Infraestructura.Base
{
    public class ConfiguracionAplicacion
    {
        public string CadenaConexion { get; set; }
        public string RutaLog { get; set; }
        public string NombreArchivoLog { get; set; }
        public string ExtensionArchivoLog { get; set; }
        //public InfoEnvioCorreo InfoEnvioCorreo { get; set; }
    }
}
