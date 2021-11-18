using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.Admin.AplicacionCore.Dto.Videos;
using Unacem.Pgs.AplicacionCore.AplicacionBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Servicios.Aplicacion
{
    public interface IServicioAplicacionVideo
    {
        Task<ResultadoServicio<VideoDto>> ConsultarVideoPorCodigo(int CodVideo);

        Task<ResultadoServicio<VideoDto>> ConsultarVideo();
        Task<ResultadoServicio<TipoPorVideoDto>> ConsultarVideoPorTipo();

    }
}
