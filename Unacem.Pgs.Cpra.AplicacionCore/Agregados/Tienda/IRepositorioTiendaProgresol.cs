using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
    public interface IRepositorioTiendaProgresol: IRepositorio<TiendaProgresol>
    {
        Task<TiendaProgresol> ObtenerAsincronoPorId(int pCodTipoPago);
        void Actualizar(TiendaProgresol pTiendaProgresol);
        TiendaProgresol Agregar(TiendaProgresol pTienda);
    }
}
