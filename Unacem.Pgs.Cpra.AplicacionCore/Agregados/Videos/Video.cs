using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Recursos;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.AplicacionCore.Excepciones;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Videos
{
    public class Video: IRaizAgregado
    {
        public Video() { }
        public Video(int pCodTipoVideo)
        {
            if(pCodTipoVideo<=0)
                throw new ProgresolExcepcionDominio(Mensajes.validacion_TiempoEntregaMenorIgualCero);

            _CodTipoVideo = pCodTipoVideo;
        }
        public int CodVideo { get; set; }
        public string DscTitulo { get; set; }
        public string DscVideo { get; set; }
        public string DscDireccionUrl { get; set; }
        public string DscActivo { get; set; }
        public string DscOrden { get; set; }
        public DateTime? FchRegistro { get; set; }
        //  public int? CodTipoVideo { get; set; }
        public int CodTipoVideo => _CodTipoVideo;
        private int _CodTipoVideo;

        public virtual TipoVideo CodTipoVideoNavigation { get; set; }
    }
}
