using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Unacem.Pgs.Admin.AplicacionCore.Dto.Videos;
using Unacem.Pgs.Admin.AplicacionCore.Servicios.Aplicacion;
using Unacem.Pgs.AplicacionCore.AplicacionBase;
using Unacem.Pgs.Cpra.API.Infraestructura.Seguridad;
using Unacem.Pgs.Cpra.AplicacionCore.Base;

namespace Unacem.Pgs.Admin.API.Controllers
{
    //[RequiereReclamaciones(ClaimTypes.Role, EnumRolTipoProgresol.ProgresolDos)]
    [Route("msadmin/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        readonly IServicioAplicacionVideo _IServicioAplicacionVideo;
        public VideoController(IServicioAplicacionVideo pIServicioAplicacionVideo)
        {
            _IServicioAplicacionVideo = pIServicioAplicacionVideo ?? throw new ArgumentException(nameof(pIServicioAplicacionVideo));
        }

        [Route("RecuperarVideoDefecto")]
        [HttpGet]
        [ProducesResponseType(typeof(ResultadoServicio<VideoDto>),(int) HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ConsultaVideo()
        {
            var VideoDefecto = await _IServicioAplicacionVideo.ConsultarVideo();

            return VideoDefecto.ResultadoId == EnumTipoResultado.OK ? (IActionResult)Ok(VideoDefecto) : (IActionResult)NotFound(VideoDefecto);
        }

        [Route("RecuperarVideoCodigo")]
        [HttpGet]
        [ProducesResponseType(typeof(ResultadoServicio<VideoDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ConsultaVideoPorCodigo(int pCodigoVideo)
        {
            var VideoDatos = await _IServicioAplicacionVideo.ConsultarVideoPorCodigo(pCodigoVideo);

            return VideoDatos.ResultadoId == EnumTipoResultado.OK ? (IActionResult)Ok(VideoDatos) : (IActionResult)NotFound(VideoDatos);
        }

        [Route("RecuperarVideoPorTipo")]
        [HttpGet]
        [ProducesResponseType(typeof(ResultadoServicio<TipoPorVideoDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ConsultaVideoPorTipo()
        {
            var VideoDatos = await _IServicioAplicacionVideo.ConsultarVideoPorTipo();

            return VideoDatos.ResultadoId == EnumTipoResultado.OK ? (IActionResult)Ok(VideoDatos) : (IActionResult)NotFound(VideoDatos);
        }
    }
}
