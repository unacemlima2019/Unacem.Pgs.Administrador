using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
    public class RangoDiaAtencion : IRaizAgregado
    {
        public int CodRangoDiaAtencion { get; set; }

        public virtual ICollection<TiendaHorarioAtencion> TiendaHorarioAtencion { get; set; }

        public string DscRangoDia { get; set; }
        public string Defecto { get; set; }
        public RangoDiaAtencion()
        {
            TiendaHorarioAtencion = new HashSet<TiendaHorarioAtencion>();
        }
     }
}
