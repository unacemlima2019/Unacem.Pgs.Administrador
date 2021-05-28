using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;
using Unacem.Pgs.AplicacionCore.DominioBase;



namespace Unacem.Pgs.Cpra.Infraestructura.Datos.Repositorios.Compras
{
    public class RepositorioProgresol : IRepositorioProgresol
    {
        private readonly ProgresolContexto _contexto;

        public IUnidadDeTrabajo UnidadDeTrabajo
        {
            get
            {
                return _contexto;
            }
        }

        public RepositorioProgresol(ProgresolContexto pProgresolContexto)
        {
            _contexto = pProgresolContexto ?? throw new ArgumentNullException(nameof(pProgresolContexto));
        }

        public async Task<Progresol> ObtenerAsincronoPorCodigoLocal(string pCodigoLocalProgresol)
        {
            var progresol = await _contexto.Progresoles.FirstOrDefaultAsync(w => w.CodigoLocalProgresolSap == pCodigoLocalProgresol);

            return progresol;
        }
    }
}
