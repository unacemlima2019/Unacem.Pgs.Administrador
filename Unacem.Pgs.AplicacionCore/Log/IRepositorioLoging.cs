using System;
using System.Collections.Generic;
using System.Text;


namespace Unacem.Pgs.AplicacionCore.Log
{
    public interface IRepositorioLoging
    {
        bool Agregar(Loging pLog);
    }
}
