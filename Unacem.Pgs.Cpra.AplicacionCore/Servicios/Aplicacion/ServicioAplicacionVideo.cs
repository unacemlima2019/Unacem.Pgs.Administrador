using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Videos;
using Unacem.Pgs.Admin.AplicacionCore.Base;
using Unacem.Pgs.Admin.AplicacionCore.Dto.Videos;
using Unacem.Pgs.Admin.AplicacionCore.Recursos;
using Unacem.Pgs.AplicacionCore.AplicacionBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Servicios.Aplicacion
{
    public class ServicioAplicacionVideo: IServicioAplicacionVideo
    {
        private IRepositorioVideo _IRepositorioVideo;
        private IRepositorioTipoVideo _IRepositorioTipoVideo;

        private Video _Video;
        public ServicioAplicacionVideo(IRepositorioVideo pIRepositorioVideo, IRepositorioTipoVideo pIRepositorioTipoVideo)
        {
            _IRepositorioVideo = pIRepositorioVideo ?? throw new ArgumentNullException(nameof(pIRepositorioVideo));

            _IRepositorioTipoVideo = pIRepositorioTipoVideo ?? throw new ArgumentNullException(nameof(pIRepositorioTipoVideo));

        }

        public async Task<ResultadoServicio<TipoPorVideoDto>> ConsultarVideoPorTipo()
        {
            try
            {
                return await ConsultarVideoXTipo();
            }
            catch (Exception ex)
            {

                Comun.RegistrarError(Mensajes.app_error_RecuperarLaInformacion, ex, "Consultar video por tipo");

                return new ResultadoServicio<TipoPorVideoDto>(EnumTipoResultado.ERROR, Mensajes.app_error_RecuperarLaInformacion, ex.Message, null, null);
            }
        }


        public async Task<ResultadoServicio<VideoDto>> ConsultarVideoPorCodigo(int CodVideo)
        {
            try
            {
                return await ConsultarVideoID(CodVideo);
            }
            catch (Exception ex)
            {

                Comun.RegistrarError(Mensajes.app_error_RecuperarLaInformacion, ex, "Consultar Video por codigo");

                return new ResultadoServicio<VideoDto>(EnumTipoResultado.ERROR, Mensajes.app_error_RecuperarLaInformacion, ex.Message, null, null);
            }
        }

        public async Task<ResultadoServicio<VideoDto>> ConsultarVideo()
        {
            try
            {
                return await RecuperarVideoPorDefecto();
            }
            catch (Exception ex)
            {

                Comun.RegistrarError(Mensajes.app_error_Consultar_VideoFallo, ex, "ConsultarVideo");
                return new ResultadoServicio<VideoDto>(EnumTipoResultado.ERROR, Mensajes.app_error_Consultar_VideoFallo, ex.Message, null, null);
            }
        }
        private async Task<ResultadoServicio<VideoDto>> RecuperarVideoPorDefecto()
        {
            List<VideoDto> oVideos = new List<VideoDto>();
            var ListaVideos = await _IRepositorioVideo.ObtenerAsincronoPorDefecto();
            if(ListaVideos!=null)
            {
                oVideos = ListaVideos.Select(e => new VideoDto()
                {
                    CodVideo = e.CodVideo,
                    CodTipoVideo = e.CodTipoVideo,
                    DscTitulo = e.DscTitulo,
                    DscVideo=e.DscVideo,
                    DscDireccionUrl = e.DscDireccionUrl,
                    DscActivo = e.DscActivo,
                    DscOrden = e.DscOrden,
                    FchRegistro = e.FchRegistro,
                    TipoVideo= RecuperarTipoVideo(e.CodTipoVideo)
                }).ToList();
            }

            return new ResultadoServicio<VideoDto>(EnumTipoResultado.OK, Mensajes.app_informacion_RecuperarVideosOk, null ,null, oVideos);
        }
        private async Task<ResultadoServicio<TipoPorVideoDto>> ConsultarVideoXTipo()
        {
            List<TipoPorVideoDto> oTipoVideo = new List<TipoPorVideoDto>();
            var ListaTipoVideo = await _IRepositorioTipoVideo.ObtenerAsincronoPorDefecto();

            if(ListaTipoVideo!=null)
            {
                oTipoVideo = ListaTipoVideo.Select(e => new TipoPorVideoDto()
                {
                    CodTipoVideo=e.CodTipoVideo,
                    DscActivo=e.DscActivo,
                    DscTipo=e.DscTipo,
                    FchRegistro=e.FchRegistro,
                    Id=e.Id,
                    Videos= RecuperarVideosPorTipo(e.CodTipoVideo)
                }).ToList();
            }

            return new ResultadoServicio<TipoPorVideoDto>(EnumTipoResultado.OK, Mensajes.app_informacion_RecuperarVideosOk, null, null, oTipoVideo);
        }

        private List<VideoDto> RecuperarVideosPorTipo(int CodTipoVideo)
        {
            List<VideoDto> oListaVideos = new List<VideoDto>();
            var oVideos = _IRepositorioVideo.ObtenerAsincronoPorTipo(CodTipoVideo).Result;

            oListaVideos = oVideos.Select(e => new VideoDto()
            {
                CodTipoVideo=e.CodTipoVideo,
                CodVideo=e.CodVideo,
                DscActivo=e.DscActivo,
                DscDireccionUrl=e.DscDireccionUrl,
                DscOrden=e.DscOrden,
                DscTitulo=e.DscTitulo,
                DscVideo=e.DscVideo,
                FchRegistro=e.FchRegistro,
            }).ToList();

            return oListaVideos;
        }
        private TipoVideoDto RecuperarTipoVideo(int CodTipoVideo)
        {
            TipoVideoDto oTipoVideoDto = new TipoVideoDto();
            TipoVideo oTipoVideo = new TipoVideo();
            oTipoVideo = _IRepositorioTipoVideo.ObtenerAsincronoPorId(CodTipoVideo).Result;

            oTipoVideoDto.CodTipoVideo = oTipoVideo.CodTipoVideo;
            oTipoVideoDto.DscActivo = oTipoVideo.DscActivo;
            oTipoVideoDto.DscTipo = oTipoVideo.DscTipo;
            oTipoVideoDto.FchRegistro = oTipoVideo.FchRegistro;
            oTipoVideoDto.Id = oTipoVideo.Id;
       

            return oTipoVideoDto;
        }
        private async Task<ResultadoServicio<VideoDto>> ConsultarVideoID(int codVideo)
        {
            VideoDto oVideo = new VideoDto();

            _Video = await _IRepositorioVideo.ObtenerAsincronoPorId(codVideo);

            if (_Video == null)
                throw new ArgumentException(Mensajes.app_error_RecuperarLaInformacion);

            oVideo.CodVideo = _Video.CodVideo;
            oVideo.CodTipoVideo = _Video.CodTipoVideo;
            oVideo.DscTitulo = _Video.DscTitulo;
            oVideo.DscDireccionUrl = _Video.DscDireccionUrl;
            oVideo.DscActivo = _Video.DscActivo;
            oVideo.DscOrden = _Video.DscOrden;
            oVideo.FchRegistro = _Video.FchRegistro;
            oVideo.TipoVideo = RecuperarTipoVideo(_Video.CodTipoVideo);

            if (_Video == null)
                throw new ArgumentException(Mensajes.app_error_RecuperarLaInformacion);

            return new ResultadoServicio<VideoDto>(EnumTipoResultado.OK, Mensajes.app_informacion_RecuperarVideosOk, string.Empty, oVideo, null);
        }
    }
}
