using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.Infraestructura.Datos.ConsultasBase;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.Consultas.Parametros
{
    public interface IConsultaParametros
    {
        Task<ModeloVista<TipoUsuarioCotizacionListadoModeloVista>> ConsultarListadoTiposUsuarioCotizacion();
        Task<ModeloVista<TipoCotizacionListadoModeloVista>> ConsultarListadoTiposCotizacion();
    }
}
