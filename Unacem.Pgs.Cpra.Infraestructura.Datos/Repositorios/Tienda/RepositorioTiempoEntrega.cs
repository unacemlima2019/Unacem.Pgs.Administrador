using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda;
using Unacem.Pgs.Cpra.Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;
using System.Linq;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.Repositorios.Tienda
{
    public class RepositorioTiempoEntrega: IRepositorioTiempoEntrega
    {
        private readonly ProgresolContexto _contexto;

        public IUnidadDeTrabajo UnidadDeTrabajo
        {
            get
            {
                return _contexto;
            }
        }

        public RepositorioTiempoEntrega(ProgresolContexto pProgresolContexto)
        {
            _contexto = pProgresolContexto ?? throw new ArgumentNullException(nameof(pProgresolContexto));
        }
        public async Task<TiempoEntrega> ObtenerAsincronoPorId(int pCodTiempoEntrega)
        {
            var TiempoEntregaBuscado = await _contexto.TiempoEntrega.FirstOrDefaultAsync(w => w.CodTiempoEntrega == pCodTiempoEntrega);

            //if (TiempoEntregaBuscado != null)
            //    await _contexto.Entry(TiempoEntregaBuscado).Reference(c => c.CodTiempoEntrega).LoadAsync();

            return TiempoEntregaBuscado;
        }

        public async Task<List<TiempoEntrega>> ObtenerAsincronoPorDefecto()
        {
            var TiempoEntregaBuscado = await _contexto.TiempoEntrega.Where(w => w.Defecto=="S" && w.DscActivo=="S").ToListAsync();
            return TiempoEntregaBuscado;
        }
    }
}
