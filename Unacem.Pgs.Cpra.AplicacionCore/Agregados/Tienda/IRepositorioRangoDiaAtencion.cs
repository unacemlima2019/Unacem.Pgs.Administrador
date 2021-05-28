using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
    public interface IRepositorioRangoDiaAtencion : IRepositorio<RangoDiaAtencion>
    {
        Task<RangoDiaAtencion> ObtenerAsincronoPorId(int pCodRangoDiaAtencion);
    }
}
