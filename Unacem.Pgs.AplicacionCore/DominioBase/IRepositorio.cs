using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.AplicacionCore.DominioBase
{
    public interface IRepositorio<T> where T : IRaizAgregado
    {
        IUnidadDeTrabajo UnidadDeTrabajo { get; }
    }
}
