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
   public class RepositorioVideo: IRepositorioVideo
    {
        private readonly ProgresolContexto _contexto;
        public IUnidadDeTrabajo UnidadDeTrabajo
        {
            get
            {
                return _contexto;
            }
        }

        
        public RepositorioVideo(ProgresolContexto pProgresolContexto)
        {
            _contexto = pProgresolContexto ?? throw new ArgumentException(nameof(pProgresolContexto));
        }

        public Video Agregar(Video pVideo)
        {
            return _contexto.Video.Add(pVideo).Entity;
        }
        public void Actualizar(Video pVideo)
        {
            _contexto.Entry(pVideo).State = EntityState.Modified;

            var VideoActual = _contexto.Video.FirstOrDefaultAsync(e => e.CodVideo == pVideo.CodVideo);

            if (VideoActual == null)
            {
                _contexto.Entry(pVideo).State = EntityState.Added;
            }
            else
                _contexto.Entry(pVideo).State = EntityState.Modified;
        }
        public async Task<Video> ObtenerAsincronoPorId(int pCodVideo)
        {
            var VideoBuscado = await _contexto.Video.FirstOrDefaultAsync(w => w.CodTipoVideo == pCodVideo);

            return VideoBuscado;

        }
        public async Task<List<Video>> ObtenerAsincronoPorDefecto()
        {
            var VideoBuscado = await _contexto.Video.Where(w => w.DscActivo == "S").ToListAsync();
            return VideoBuscado;
        }

        public async Task<List<Video>> ObtenerAsincronoPorTipo(int pCodTipo)
        {
            var VideoBuscado = await _contexto.Video.Where(w => w.DscActivo == "S" && w.CodTipoVideo==pCodTipo).ToListAsync();
            return VideoBuscado;
        }
    }
}
