using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Unacem.Pgs.Admin.AplicacionCore.Servicios.Aplicacion;
using Unacem.Pgs.AplicacionCore.AplicacionBase;
using Unacem.Pgs.Cpra.API.Infraestructura.Seguridad;
using Unacem.Pgs.Cpra.AplicacionCore.Base;
using Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda;

namespace Unacem.Pgs.Admin.API.Controllers
{

    //[RequiereReclamaciones(ClaimTypes.Role, EnumRolTipoProgresol.ProgresolDos)]
    [Route("msadmin/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        
        readonly IServicioAplicacionTienda _IServicioAplicacionTienda;
        public TiendaController(IServicioAplicacionTienda pIServicioAplicacionTienda)
        {
            _IServicioAplicacionTienda = pIServicioAplicacionTienda ??
                  throw new ArgumentNullException(nameof(pIServicioAplicacionTienda));
        }

        [Route("agregarTienda")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AgregarTiendaProgresol([FromBody] TiendaDto pTiendaDto,
                                                                [FromHeader(Name = "x-requestid")] string TiendaId)
        {
            if (pTiendaDto == null)
                return BadRequest("La Tienda a generar no puede ser nulo. Vuelva a intentarlo por favor.");

            var resultadoTiendaCreada = await _IServicioAplicacionTienda.AgregarTienda(pTiendaDto);

            return resultadoTiendaCreada.ResultadoId == EnumTipoResultado.OK ?
                    (IActionResult)Ok(resultadoTiendaCreada) :
                    (IActionResult)BadRequest(resultadoTiendaCreada);
        }



        [Route("ActualizarTienda")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ActualizarTiendaProgresol([FromBody] TiendaDto pTiendaDto,
                                                                [FromHeader(Name = "x-requestid")] string TiendaId)
        {
            if (pTiendaDto == null)
                return BadRequest("La Tienda a generar no puede ser nulo. Vuelva a intentarlo por favor.");

            var resultadoTiendaCreada = await _IServicioAplicacionTienda.ActualizadoTienda(pTiendaDto);

            return resultadoTiendaCreada.ResultadoId == EnumTipoResultado.OK ?
                    (IActionResult)Ok(resultadoTiendaCreada) :
                    (IActionResult)BadRequest(resultadoTiendaCreada);
        }

    }
}
