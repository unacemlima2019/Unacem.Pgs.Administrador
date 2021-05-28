using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Infraestructura.Archivos
{
    public interface IArchivo
    {
        bool EsccribirArchivoAdjuntandoTexto(IEnumerable<string> pConenido, string pRuta, string pNombre, string pExtensionArchivo);
    }
}
