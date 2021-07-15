﻿using Microsoft.AspNetCore.Http;
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


        [Route("consultarTiposUsuarioCotizacion")]
        [HttpGet]
        [ProducesResponseType(typeof(ModeloVista<TipoUsuarioCotizacionListadoModeloVista>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ConsultarTiposUsuarioCotizacion()
        {
            var tiposUsuarioCotizacion = await _IConsultaParametros.ConsultarTiposUsuarioCotizacion();

            return tiposUsuarioCotizacion.ResultadoConsulta.CodigoResultado == EnumTipoResultado.OK ?
                    (IActionResult)Ok(tiposUsuarioCotizacion) :
                    (IActionResult)NotFound(tiposUsuarioCotizacion);
        }
    }
}
