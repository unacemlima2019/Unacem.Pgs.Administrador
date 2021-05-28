using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using Unacem.Pgs.Infraestructura.Archivos;

namespace Unacem.Pgs.Cpra.Infraestructura.Net.Archivos
{
    public sealed class ArchivoFuente : IArchivo
    {
        public bool EsccribirArchivoAdjuntandoTexto(IEnumerable<string> pConenido, string pRuta, 
                                                        string pNombre, string pExtensionArchivo)
        {
            string rutaYNombreArchivo = pRuta + pNombre + pExtensionArchivo;
            using (StreamWriter sw = File.AppendText(rutaYNombreArchivo))
            {
                foreach (string lineaTexto in pConenido)
                {
                    sw.WriteLine(lineaTexto);
                }
            }

            return true;
        }
    }
}
