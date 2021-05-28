using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Infraestructura.Archivos;

namespace Unacem.Pgs.Cpra.Infraestructura.Net.Archivos
{
    public class ArchivoFuenteFactory : IArchivoFactory
    {
        public IArchivo Crear()
        {
            return new ArchivoFuente();
        }
    }
}
