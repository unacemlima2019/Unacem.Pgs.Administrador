using System;
using AutoMapper;
using Unacem.Pgs.Infraestructura.Adaptador;

namespace Unacem.Pgs.Cpra.Infraestructura.Net.Adaptador
{
    public class AutomapperTipoAdaptador : ITipoAdaptador
    {
        public TDestino Adapt<TOrigen, TDestino>(TOrigen origen)
            where TOrigen : class
            where TDestino : class, new()
        {
            return Mapper.Map<TOrigen, TDestino>(origen);
        }

        public TDestino Adapt<TDestino>(object origen) where TDestino : class, new()
        {
            return Mapper.Map<TDestino>(origen);
        }
    }
}
