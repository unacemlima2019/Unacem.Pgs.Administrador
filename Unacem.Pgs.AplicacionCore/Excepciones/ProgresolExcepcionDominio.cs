using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.AplicacionCore.Excepciones
{
    public class ProgresolExcepcionDominio : Exception
    {
        public ProgresolExcepcionDominio() { }

        public ProgresolExcepcionDominio(string mensaje)
            : base(mensaje)
        { }

        public ProgresolExcepcionDominio(string mensaje, Exception excepcionInterna)
            : base(mensaje, excepcionInterna)
        {

        }
    }
}
