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
    public class RepositorioTipoPago: IRepositorioTipoPago
    {
        private readonly ProgresolContexto _contexto;

        public IUnidadDeTrabajo UnidadDeTrabajo
        {
            get
            {
                return _contexto;
            }
        }

        public RepositorioTipoPago(ProgresolContexto pProgresolContexto)
        {
            _contexto = pProgresolContexto ?? throw new ArgumentNullException(nameof(pProgresolContexto));
        }
        public async Task<TipoPago> ObtenerAsincronoPorId(int pCodTipoPago)
        {
            var TipoPagoBuscado = await _contexto.TipoPago.FirstOrDefaultAsync(w => w.CodTipoPago == pCodTipoPago);

            //if (TipoPagoBuscado != null)
            //    await _contexto.Entry(TipoPagoBuscado).Reference(c => c.TiendaTipoPago).LoadAsync();

            return TipoPagoBuscado;
        }

    }
}
