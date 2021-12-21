using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Unacem.Pgs.Admin.Infraestructura.Datos.Consultas.Parametros;
using Unacem.Pgs.AplicacionCore.AplicacionBase;
using Unacem.Pgs.Infraestructura.Datos.ConsultasBase;

namespace Unacem.Pgs.Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosController : ControllerBase
    {
        readonly IConsultaParametros _IConsultaParametros;

        public ParametrosController(IConsultaParametros pIConsultaParametros)
        {
            _IConsultaParametros = pIConsultaParametros ??
                    throw new ArgumentNullException(nameof(pIConsultaParametros));
        }


        [Route("consultarListadoTiposUsuarioCotizacion")]
        [HttpGet]
        [ProducesResponseType(typeof(ModeloVista<TipoUsuarioCotizacionListadoModeloVista>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ConsultarListadoTiposUsuarioCotizacion()
        {
            var tiposUsuarioCotizacion = await _IConsultaParametros.ConsultarListadoTiposUsuarioCotizacion();

            return tiposUsuarioCotizacion.ResultadoConsulta.CodigoResultado == EnumTipoResultado.OK ?
                    (IActionResult)Ok(tiposUsuarioCotizacion) :
                    (IActionResult)NotFound(tiposUsuarioCotizacion);
        }


        [Route("consultarListadoTiposCotizacion")]
        [HttpGet]
        [ProducesResponseType(typeof(ModeloVista<TipoCotizacionListadoModeloVista>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ConsultarListadoTiposCotizacion()
        {
            var tiposCotizacion = await _IConsultaParametros.ConsultarListadoTiposCotizacion();

            return tiposCotizacion.ResultadoConsulta.CodigoResultado == EnumTipoResultado.OK ?
                    (IActionResult)Ok(tiposCotizacion) :
                    (IActionResult)NotFound(tiposCotizacion);
        }


        [Route("consultarListadoZonificacionesProgresol")]
        [HttpGet]
        [ProducesResponseType(typeof(ModeloVista<ZonificacionProgresolModeloVista>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ConsultarListadoZonificacionesProgresol()
        {
            var zonificaciones = await _IConsultaParametros.ConsultarListadoZonificacionesProgresol();

            return zonificaciones.ResultadoConsulta.CodigoResultado == EnumTipoResultado.OK ?
                    (IActionResult)Ok(zonificaciones) :
                    (IActionResult)NotFound(zonificaciones);
        }


        [Route("consultarListadoUbigeosProgresol")]
        [HttpGet]
        [ProducesResponseType(typeof(ModeloVista<UbigeosProgresolModeloVista>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ConsultarListadoUbigeosProgresol()
        {
            var ubigeos = await _IConsultaParametros.ConsultarListadoUbigeosProgresol();

            return ubigeos.ResultadoConsulta.CodigoResultado == EnumTipoResultado.OK ?
                    (IActionResult)Ok(ubigeos) :
                    (IActionResult)NotFound(ubigeos);
        }

        [Route("consultarListadoCategorizacionYFiltroDeMateriales/{pCategoriaMaterial}/{pMostrarFiltroCategoria}/{pMostrarFiltroTipo}/{pMostrarFiltroMarca}/{pMostrarFiltroUso}/{pMostrarFiltroCaracteristica}")]
        [HttpGet]
        [ProducesResponseType(typeof(ModeloVista<CategorizacionYFiltroDeMaterialesModeloVista>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ConsultarListadoCategorizacionYFiltroDeMateriales(Guid pCategoriaMaterial,
                                                                        bool pMostrarFiltroCategoria, bool pMostrarFiltroTipo, bool pMostrarFiltroMarca,
                                                                        bool pMostrarFiltroUso, bool pMostrarFiltroCaracteristica)
        {

            var categorizacionYFiltroDeMateriales = await _IConsultaParametros.ConsultarListadoCategorizacionYFiltroDeMateriales(pCategoriaMaterial,
                                                                        pMostrarFiltroCategoria, pMostrarFiltroTipo, pMostrarFiltroMarca,
                                                                        pMostrarFiltroUso, pMostrarFiltroCaracteristica);

            return categorizacionYFiltroDeMateriales.ResultadoConsulta.CodigoResultado == EnumTipoResultado.OK ?
                    (IActionResult)Ok(categorizacionYFiltroDeMateriales) :
                    (IActionResult)NotFound(categorizacionYFiltroDeMateriales);
        }
    }
}
