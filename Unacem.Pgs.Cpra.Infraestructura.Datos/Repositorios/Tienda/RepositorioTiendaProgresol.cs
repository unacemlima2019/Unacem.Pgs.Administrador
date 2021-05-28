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
   public class RepositorioTiendaProgresol: IRepositorioTiendaProgresol
    {
        private readonly ProgresolContexto _contexto;

        public IUnidadDeTrabajo UnidadDeTrabajo
        {
            get
            {
                return _contexto;
            }
        }

        public RepositorioTiendaProgresol(ProgresolContexto pProgresolContexto)
        {
            _contexto = pProgresolContexto ?? throw new ArgumentNullException(nameof(pProgresolContexto));
        }

        public TiendaProgresol Agregar(TiendaProgresol pTienda)
        {
            return _contexto.TiendaProgresol.Add(pTienda).Entity;
        }

        public void Actualizar(TiendaProgresol pTiendaProgresol)
        {
            _contexto.Entry(pTiendaProgresol).State = EntityState.Modified;

            var TiendaProgresolActual = _contexto.TiendaProgresol.FirstOrDefaultAsync(e => e.CodTiendaProgresol == pTiendaProgresol.CodTiendaProgresol);

            if (TiendaProgresolActual == null)
            {
                _contexto.Entry(pTiendaProgresol).State = EntityState.Added;
            }
            else
                _contexto.Entry(pTiendaProgresol).State = EntityState.Modified;
        }
        public async Task<TiendaProgresol> ObtenerAsincronoPorId(int pCodTienda)
        {
            var TiendaProgresolBuscado = await _contexto.TiendaProgresol.FirstOrDefaultAsync(w => w.CodTiendaProgresol == pCodTienda);

            //if (TiendaProgresolBuscado != null)
            //    await _contexto.Entry(TiendaProgresolBuscado).Reference(c => c.TiendaTipoPago).LoadAsync();

            return TiendaProgresolBuscado;
        }
    }
}
