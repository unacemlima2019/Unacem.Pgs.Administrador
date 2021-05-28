using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Infraestructura.Adaptador
{
    public static class TipoAdaptadorFactory
    {
        static ITipoAdaptadorFactory _actualITipoAdaptadorFactory = null;

        public static void EstablecerActual(ITipoAdaptadorFactory adaptarFactory)
        {
            _actualITipoAdaptadorFactory = adaptarFactory;
        }

        public static ITipoAdaptador CrearAdaptador()
        {
            return _actualITipoAdaptadorFactory.Crear();
        }
    }
}
