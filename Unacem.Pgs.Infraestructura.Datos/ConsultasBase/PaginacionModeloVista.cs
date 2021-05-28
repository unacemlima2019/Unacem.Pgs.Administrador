using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Infraestructura.Datos.ConsultasBase
{
    public class PaginacionModeloVista<TEntidad> where TEntidad : class
    {
        public int PaginaIndice { get; private set; }

        public int CantidadPagina { get; private set; }

        public long RegistrosTotal { get; private set; }

        public IEnumerable<TEntidad> Datos { get; private set; }

        public PaginacionModeloVista(int pPaginaIndice, int pCantidadPagina,
                                            long pRegistrosTotal, IEnumerable<TEntidad> pDatos)
        {
            this.PaginaIndice = pPaginaIndice;
            this.CantidadPagina = pCantidadPagina;
            this.RegistrosTotal = pRegistrosTotal;
            this.Datos = pDatos;
        }
    }
}
