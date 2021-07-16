using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.Consultas.Parametros
{
    public class TipoUsuarioCotizacionListadoModeloVista
    {
        public Guid id { get; set; }
        public string descripcionTipoUsuarioCotizacion { get; set; }
    }

    public class TipoCotizacionListadoModeloVista
    {
        public Guid id { get; set; }
        public string descripcionTipoCotizacion { get; set; }
        public string abreviaturaTipoCotizacion { get; set; }

    }

}
