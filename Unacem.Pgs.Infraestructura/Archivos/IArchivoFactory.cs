using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Infraestructura.Archivos
{
    public interface IArchivoFactory
    {
        IArchivo Crear();
    }
}
