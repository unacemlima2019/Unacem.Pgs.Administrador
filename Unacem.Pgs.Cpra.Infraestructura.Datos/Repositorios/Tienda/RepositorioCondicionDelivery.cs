using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda;
using Unacem.Pgs.Cpra.Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.Repositorios.Tienda
{
   public class RepositorioCondicionDelivery: IRepositorioCondicionDelivery
    {
        private readonly ProgresolContexto _contexto;

        public IUnidadDeTrabajo UnidadDeTrabajo
        {
            get
            {
                return _contexto;
            }
        }
        public RepositorioCondicionDelivery(ProgresolContexto pProgresolContexto)
        {
            _contexto = pProgresolContexto ?? throw new ArgumentNullException(nameof(pProgresolContexto));
        }

        //public CondicionesDelivery Agregar(CondicionesDelivery  pCondicionesDelivery)
        //{

        //}

        public async Task<CondicionesDelivery> ObtenerAsincronoPorId(int  pCondicionDeliveryId)
        {
            var CondicionDeliveryBuscado = await _contexto.CondicionDelivery.FirstOrDefaultAsync(w => w.CodCondicionDelivery ==pCondicionDeliveryId);

            //if (CondicionDeliveryBuscado != null)
            //    await _contexto.Entry(CondicionDeliveryBuscado).Reference(c => c.TiendaCondicionDelivery).LoadAsync();

            return CondicionDeliveryBuscado;
        }
    }
}
