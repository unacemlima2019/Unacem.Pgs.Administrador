using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Videos
{
   public class TipoVideo: IRaizAgregado
    {
        public TipoVideo()
        {
            Videos = new HashSet<Video>();
        }

        public int CodTipoVideo { get; set; }
        public Guid Id { get; set; }
        public string DscTipo { get; set; }
        public string DscActivo { get; set; }
        public DateTime? FchRegistro { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
    }
}
