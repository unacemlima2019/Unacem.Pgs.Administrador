using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Videos
{
   public interface IRepositorioTipoVideo
    {
        Task<TipoVideo> ObtenerAsincronoPorId(int pCodTipoVideo);
        Task<List<TipoVideo>> ObtenerAsincronoPorDefecto();
    }
}
