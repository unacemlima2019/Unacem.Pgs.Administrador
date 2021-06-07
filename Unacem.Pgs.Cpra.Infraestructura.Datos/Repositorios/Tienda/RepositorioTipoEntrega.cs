using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.Cpra.Infraestructura.Datos;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.Repositorios.Tienda
{
public class RepositorioTipoEntrega: IRepositorioTipoEntrega
    {
        private readonly ProgresolContexto _contexto;

        public IUnidadDeTrabajo UnidadDeTrabajo
        {
            get
            {
                return _contexto;
            }
        }

        public RepositorioTipoEntrega(ProgresolContexto pProgresolContexto)
        {
            _contexto = pProgresolContexto ?? throw new ArgumentNullException(nameof(pProgresolContexto));
        }
        public async Task<TipoEntrega> ObtenerAsincronoPorId(int pCodTipoEntrega)
        {
            var TipoEntregaBuscado = await _contexto.TipoEntrega.FirstOrDefaultAsync(w => w.CodTipoEntrega == pCodTipoEntrega);

            if (TipoEntregaBuscado != null)
                await _contexto.Entry(TipoEntregaBuscado).Reference(c => c.TiendaTipoEntrega).LoadAsync();

            return TipoEntregaBuscado;
        }

        public async Task<TipoEntrega> ObtenerAsincronoPorDefecto()
        {
            var TipoEntregaBuscado = await _contexto.TipoEntrega.FirstOrDefaultAsync(w => w.Defecto == "S");
            return TipoEntregaBuscado;
        }


    }
}
