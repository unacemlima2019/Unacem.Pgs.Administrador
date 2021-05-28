using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
    public interface IRepositorioTipoEntrega:IRepositorio<TipoEntrega>
    {
        Task<TipoEntrega> ObtenerAsincronoPorId(int pTipoEntrega);
    }
}
