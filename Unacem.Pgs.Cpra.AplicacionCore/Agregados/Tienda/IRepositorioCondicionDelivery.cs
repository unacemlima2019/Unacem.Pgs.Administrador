using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
    public interface IRepositorioCondicionDelivery: IRepositorio<CondicionesDelivery>
    {
        Task<CondicionesDelivery> ObtenerAsincronoPorId(int pCondicionDeliveryId);

        Task<List<CondicionesDelivery>> ObtenerAsincronoPorDefecto();
    }
}
