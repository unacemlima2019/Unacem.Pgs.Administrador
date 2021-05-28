using System;
using System.Collections.Generic;
using System.Text;


namespace Unacem.Pgs.Infraestructura.Datos.ConsultasBase
{
    public class ModeloVista<TEntidad> where TEntidad : class
    {
        public ResultadoConsulta ResultadoConsulta { get; private set; }
        public TEntidad Dato { get; private set; }
        public IEnumerable<TEntidad> Datos { get;  private set; }

        public ModeloVista(){}

        public ModeloVista(ResultadoConsulta pResultadoConsulta, TEntidad pDato,
                                    IEnumerable<TEntidad> pDatos)
        {
            this.ResultadoConsulta = pResultadoConsulta;
            this.Dato = pDato;
            this.Datos = pDatos;
        }
    }
}
