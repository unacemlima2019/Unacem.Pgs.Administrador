using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Infraestructura.Log;

namespace Unacem.Pgs.Admin.AplicacionCore.Base
{
    public class Comun
    {
        public static void RegistrarError(string pMensaje, Exception pException, params object[] pArgumentos)
        {
            LogFactory.CrearLog().LogError(pMensaje, pException, pArgumentos);
        }
    }
}
