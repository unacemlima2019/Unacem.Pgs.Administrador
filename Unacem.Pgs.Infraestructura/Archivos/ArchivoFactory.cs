using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Infraestructura.Archivos
{
    public static class ArchivoFactory
    {
        static IArchivoFactory _IArchivoFactory = null;

        public static void EstablecerArchivoFactory(IArchivoFactory pIArchivoFactory)
        {
            _IArchivoFactory = pIArchivoFactory;
        }


        public static IArchivo CrearArchivo()
        {
            return (_IArchivoFactory != null) ? _IArchivoFactory.Crear() : null;
        }
    }
}
