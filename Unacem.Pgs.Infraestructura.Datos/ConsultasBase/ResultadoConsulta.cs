using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Infraestructura.Datos.ConsultasBase
{    
    public class ResultadoConsulta
    {
        public int CodigoResultado { get; set; }
        public string DescripcionResultado { get; set; }
        public string DetallesResultado { get; set; }
        public int TotalRegistros { get; set; }

        public ResultadoConsulta() { }
    }
}
