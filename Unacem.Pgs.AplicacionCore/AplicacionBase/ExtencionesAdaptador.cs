using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.Infraestructura.Adaptador;

namespace Unacem.Pgs.AplicacionCore.AplicacionBase
{
    public static class ExtencionesAdaptador
    {
        public static TAdaptacion AdaptadoComo<TAdaptacion>(this Entidad item)
            where TAdaptacion : class, new()
        {
            var adaptador = TipoAdaptadorFactory.CrearAdaptador();
            return adaptador.Adapt<TAdaptacion>(item);
        }

        public static List<TAdaptacion> AdaptadoComoColeccion<TAdaptacion>(this IEnumerable<Entidad> items)
        {
            var adaptador = TipoAdaptadorFactory.CrearAdaptador();
            return adaptador.Adapt<List<TAdaptacion>>(items);
        }
    }
}
