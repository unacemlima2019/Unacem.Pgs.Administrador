using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
    public interface IRepositorioTiempoEntrega:IRepositorio<TiempoEntrega>
    {
        Task<TiempoEntrega> ObtenerAsincronoPorId(int pCodTiempoEntrega);
        Task<List<TiempoEntrega>> ObtenerAsincronoPorDefecto();
    }
}
