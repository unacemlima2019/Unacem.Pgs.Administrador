using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.Cpra.Infraestructura.Datos;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.Repositorios.Tienda
{
    public class RepositorioRangoDiaAtencion: IRepositorioRangoDiaAtencion
    {
        private readonly ProgresolContexto _contexto;
        public IUnidadDeTrabajo UnidadDeTrabajo
        {
            get
            {
                return _contexto;
            }
        }
        public RepositorioRangoDiaAtencion(ProgresolContexto pProgresolContexto)
        {
            _contexto = pProgresolContexto ?? throw new ArgumentNullException(nameof(pProgresolContexto));
        }

        public async Task<RangoDiaAtencion> ObtenerAsincronoPorId(int pCodRangoDiaAtencion)
        {
            var RangoDiaAtencionBuscado = await _contexto.RangoDiaAtencion.FirstOrDefaultAsync(e => e.CodRangoDiaAtencion == pCodRangoDiaAtencion);
            //if(RangoDiaAtencionBuscado!=null)
            //{
            //    await _contexto.Entry(RangoDiaAtencionBuscado)
            //      .Collection(w => w.TiendaHorarioAtencion)
            //      .Query()
            //      .LoadAsync();
            //}

            return RangoDiaAtencionBuscado;
        }

        public async Task<List<RangoDiaAtencion>> ObtenerAsincronoPorDefecto()
        {
            var RangoDiaAtencionBuscado = await _contexto.RangoDiaAtencion.Where(e => e.Defecto == "S").ToListAsync();
            return RangoDiaAtencionBuscado;
        }
    }
}
