using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Videos;

namespace Unacem.Pgs.Admin.AplicacionCore.Dto.Videos
{
    public class VideoDto
    {
        public int CodVideo { get; set; }
        public string DscTitulo { get; set; }
        public string DscVideo { get; set; }
        public string DscDireccionUrl { get; set; }
        public string DscActivo { get; set; }
        public string DscOrden { get; set; }
        public DateTime? FchRegistro { get; set; }
        public int CodTipoVideo { get; set; }
        public TipoVideoDto TipoVideo { get; set; }
    }
}
