using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Infraestructura.Adaptador
{
    public interface ITipoAdaptadorFactory
    {
        ITipoAdaptador Crear();
    }
}
