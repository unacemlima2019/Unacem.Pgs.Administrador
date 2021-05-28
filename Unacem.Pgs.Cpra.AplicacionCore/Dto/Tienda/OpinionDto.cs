using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda
{
    public class OpinionDto
    {
        public int CodOpiniones { get; set; }
        public string DscComentario { get; set; }
        public int? NumPuntuacion { get; set; }
        public int? CodTiendaProgresol { get; set; }

        //public virtual TiendaDto CodTiendaProgresolNavigation { get; set; }
    }
}
