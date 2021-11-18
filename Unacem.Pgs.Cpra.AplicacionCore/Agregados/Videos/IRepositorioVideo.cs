using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Videos;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Videos
{
    public interface IRepositorioVideo:IRepositorio<Video>
    {
        Task<Video> ObtenerAsincronoPorId(int pCodVideo);
        Task<List<Video>> ObtenerAsincronoPorDefecto();
        void Actualizar(Video pVideo);
        Video Agregar(Video pVideo);
        Task<List<Video>> ObtenerAsincronoPorTipo(int pCodTipo);
    }
}
