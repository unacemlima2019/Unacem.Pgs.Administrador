using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Infraestructura.Adaptador
{
    public interface ITipoAdaptador
    {
        TDestino Adapt<TOrigen, TDestino>(TOrigen origen)
            where TDestino : class, new()
            where TOrigen : class;

        TDestino Adapt<TDestino>(object origen)
            where TDestino : class, new();
    }
}
