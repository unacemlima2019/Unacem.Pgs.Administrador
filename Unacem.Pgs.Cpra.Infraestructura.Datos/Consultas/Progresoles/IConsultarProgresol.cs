using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.Infraestructura.Datos.ConsultasBase;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.Consultas.Progresoles
{
    public interface IConsultarProgresol
    {
        Task<ModeloVista<ModeloVistaProgresol>> ConsultaDatosProgresol();
    }
}
