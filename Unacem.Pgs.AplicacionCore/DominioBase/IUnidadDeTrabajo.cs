using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Unacem.Pgs.AplicacionCore.DominioBase
{
    public interface IUnidadDeTrabajo: IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)); //antes GrabarCambiosAsincronicamente; pedia implementacion
        Task<bool> GrabarAsincronicamenteEntidad(CancellationToken tokenDeCancelacion = default(CancellationToken));

        ////TODO
        //bool GrabarEntidad();
    }
}
