using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
    public interface IRepositorioProductosDestacados: IRepositorio<ProductoDestacados>
    {
        Task<ProductoDestacados> ObtenerAsincronoPorId(int pProductosDestacados);

        Task<List<ProductoDestacados>> ObtenerAsincronoPorDefecto();
    }
}
