using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Admin.AplicacionCore.Dto.Videos
{
    public class TipoPorVideoDto
    {
        public int CodTipoVideo { get; set; }
        public Guid Id { get; set; }
        public string DscTipo { get; set; }
        public string DscActivo { get; set; }
        public DateTime? FchRegistro { get; set; }
        public List<VideoDto> Videos { get; set; }
    }
}
