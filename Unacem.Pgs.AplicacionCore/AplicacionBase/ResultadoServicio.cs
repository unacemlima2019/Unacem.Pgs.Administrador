using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.AplicacionCore.AplicacionBase
{
    public class ResultadoServicio<TEntidad> where TEntidad : class
    {
        public int ResultadoId { get; private set; }

        public string DescripcionResultado { get; private set; }

        public string Detalles { get; private set; }

        public TEntidad Dato { get; private set; }
        public IEnumerable<TEntidad> Datos { get; private set; }

        public ResultadoServicio(int pResultadoId, string pDescripcionResultado,
                                            string pDetalles, TEntidad pDato, IEnumerable<TEntidad> pDatos)
        {
            this.ResultadoId = pResultadoId;
            this.DescripcionResultado = pDescripcionResultado;
            this.Detalles = pDetalles;
            this.Dato = pDato;
            this.Datos = pDatos;
        }
    }
}
