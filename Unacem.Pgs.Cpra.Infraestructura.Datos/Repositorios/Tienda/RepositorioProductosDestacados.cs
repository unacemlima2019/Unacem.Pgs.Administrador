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
    public class RepositorioProductosDestacados:IRepositorioProductosDestacados
    {
        private readonly ProgresolContexto _contexto;

        public IUnidadDeTrabajo UnidadDeTrabajo
        {
            get
            {
                return _contexto;
            }
        }

        public RepositorioProductosDestacados(ProgresolContexto pProgresolContexto)
        {
            _contexto = pProgresolContexto ?? throw new ArgumentNullException(nameof(pProgresolContexto));
        }
        public async Task<ProductoDestacados> ObtenerAsincronoPorId(int pProductosDestacados)
        {
            var ProductosDestacadosBuscado = await _contexto.ProductoDestacados.FirstOrDefaultAsync(w => w.CodProductoDestacado == pProductosDestacados);

            //if (ProductosDestacadosBuscado != null)
            //    await _contexto.Entry(ProductosDestacadosBuscado).Reference(c => c.TiendaProductoDestacado).LoadAsync();

            return ProductosDestacadosBuscado;
        }

    }
}
