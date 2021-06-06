using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Unacem.Pgs.Admin.Infraestructura.Datos.Consultas;
using Unacem.Pgs.AplicacionCore.AplicacionBase;
using Unacem.Pgs.Cpra.API.Infraestructura.Seguridad;
using Unacem.Pgs.Cpra.AplicacionCore.Base;
using Unacem.Pgs.Infraestructura.Datos.ConsultasBase;

namespace Unacem.Pgs.Admin.API.Controllers
{
    [RequiereReclamaciones(ClaimTypes.Role, EnumRolTipoProgresol.ProgresolDos)]
    [Route("msadmin/[controller]")]
    [ApiController]
    public class ProgresolController : ControllerBase
    {
        readonly IConsultarProgresol _IConsultarProgresol;
        public ProgresolController(IConsultarProgresol pIConsultarProgresol)
        {
            _IConsultarProgresol = pIConsultarProgresol ??
                    throw new ArgumentNullException(nameof(pIConsultarProgresol));
        }

        [Route("consultarProgresol")]
        [HttpGet]
        [ProducesResponseType(typeof(ModeloVista<ModeloVistaProgresol>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ConsultaProgresol()
        {
            var TempProgresol = await _IConsultarProgresol.ConsultaDatosProgresol();

            return TempProgresol.ResultadoConsulta.CodigoResultado == EnumTipoResultado.OK ? (IActionResult)Ok(TempProgresol) : (IActionResult)NotFound(TempProgresol);
        }
    }
}
