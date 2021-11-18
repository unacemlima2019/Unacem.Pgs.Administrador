using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Videos;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.Cpra.Infraestructura.Datos;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.Repositorios.Videos
{
   public class RepositorioTipoVideo: IRepositorioTipoVideo
    {
        public readonly ProgresolContexto _contexto;

        public IUnidadDeTrabajo UnidadDeTrabajo
        {
            get
            {
                return _contexto;
            }
        }


        public RepositorioTipoVideo(ProgresolContexto pProgresolContexto)
        {
            _contexto = pProgresolContexto ?? throw new ArgumentException(nameof(pProgresolContexto));
        }
        public async Task<TipoVideo> ObtenerAsincronoPorId(int pCodTipoVideo)
        {
            var TipoVideoBuscado = await _contexto.TipoVideo.FirstOrDefaultAsync(w => w.CodTipoVideo == pCodTipoVideo);

            return TipoVideoBuscado;

        }
        public async Task<List<TipoVideo>> ObtenerAsincronoPorDefecto()
        {
            var TipoVideoBuscado = await _contexto.TipoVideo.Where(w => w.DscActivo == "S").ToListAsync();
            return TipoVideoBuscado;
        }
    }
}
