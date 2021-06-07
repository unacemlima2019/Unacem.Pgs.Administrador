using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.Admin.AplicacionCore.Dto.Tienda;
using Unacem.Pgs.AplicacionCore.AplicacionBase;
using Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda;

namespace Unacem.Pgs.Admin.AplicacionCore.Servicios.Aplicacion
{
   public interface IServicioAplicacionTienda
    {
        Task<ResultadoServicio<TiendaCreadaDto>> AgregarTienda(TiendaDto pCompraDto);
        Task<ResultadoServicio<TiendaActualizadoDto>> ActualizadoTienda(TiendaDto pTiendaDto);
        Task<ResultadoServicio<TiendaDto>> ConsultarTienda();
    }
}
