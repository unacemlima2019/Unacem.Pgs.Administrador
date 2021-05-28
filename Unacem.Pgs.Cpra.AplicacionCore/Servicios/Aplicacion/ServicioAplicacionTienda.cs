using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;
using Unacem.Pgs.Admin.AplicacionCore.Base;
using Unacem.Pgs.Admin.AplicacionCore.Dto.Tienda;
using Unacem.Pgs.Admin.AplicacionCore.Recursos;
using Unacem.Pgs.AplicacionCore.AplicacionBase;
using Unacem.Pgs.AplicacionCore.Excepciones;
using Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda;

namespace Unacem.Pgs.Admin.AplicacionCore.Servicios.Aplicacion
{
    public class ServicioAplicacionTienda: IServicioAplicacionTienda
    {

        private IRepositorioProgresol _IRepositorioProgresol;
        private IRepositorioCondicionDelivery _IRepositorioCondicionDelivery;
        private IRepositorioProductosDestacados _IRepositorioProductosDestacados;
        //private IRepositorioTipoEntrega _IRepositorioTipoEntrega;
        private IRepositorioTiempoEntrega _IRepositorioTiempoEntrega;
        private IRepositorioTipoPago _IRepositorioTipoPago;
        private IRepositorioTiendaProgresol _IRepositorioTiendaProgresol;
        private IRepositorioRangoDiaAtencion _IRepositorioRangoDiaAtencion;
        //private TiendaCondicionDelivery _IRepositorioTiendaCondicionDelivery;


        private CondicionesDelivery _TiendacondicionDelivery;
        private ProductoDestacados _ProductoDestacados;
        //private TipoEntrega _TipoEntrega;
        private TiempoEntrega _TiempoEntrega;
        private TipoPago _TipoPago;
        //private TiendaProgresol _TiendaProgresol;
        public ServicioAplicacionTienda(IRepositorioProgresol pIRepositorioProgresol, IRepositorioCondicionDelivery pIRepositorioCondicionDelivery, IRepositorioProductosDestacados pRepositorioProductosDestacados,
            IRepositorioTiempoEntrega pRepositorioTiempoEntrega,
            IRepositorioTipoPago pRepositorioTipoPago,
            IRepositorioTiendaProgresol pTiendaProgresol,
            IRepositorioRangoDiaAtencion pRangoDiaAtencion)
        {
            _IRepositorioProgresol = pIRepositorioProgresol ?? throw new ArgumentNullException(nameof(pIRepositorioProgresol));
            _IRepositorioCondicionDelivery = pIRepositorioCondicionDelivery ?? throw new ArgumentNullException(nameof(pIRepositorioCondicionDelivery));
            _IRepositorioProductosDestacados = pRepositorioProductosDestacados ?? throw new ArgumentNullException(nameof(pRepositorioProductosDestacados));

            _IRepositorioTiempoEntrega = pRepositorioTiempoEntrega ?? throw new ArgumentNullException(nameof(pRepositorioTiempoEntrega));

            _IRepositorioTipoPago = pRepositorioTipoPago ?? throw new ArgumentNullException(nameof(pRepositorioTipoPago));

            _IRepositorioTiendaProgresol = pTiendaProgresol ?? throw new ArgumentNullException(nameof(pTiendaProgresol));

            _IRepositorioRangoDiaAtencion = pRangoDiaAtencion ?? throw new ArgumentNullException(nameof(pRangoDiaAtencion));
        }
        public async Task<ResultadoServicio<TiendaCreadaDto>> AgregarTienda(TiendaDto pTiendaDto)
        {
            try
            {
                return await RegistrarTienda(pTiendaDto);
            }
            catch (Exception ex)
            {
                Comun.RegistrarError(Mensajes.app_error_CreacionNuevaTiendaFallo, ex, "AgregarCompra");

                return new ResultadoServicio<TiendaCreadaDto>(EnumTipoResultado.ERROR,
                             Mensajes.app_error_CreacionNuevaTiendaFallo,
                             ex.Message, null, null);
            }
        }

        #region Metodos Privados
        private  async Task<ResultadoServicio<TiendaCreadaDto>> RegistrarTienda(TiendaDto pTiendaDto)
        {

            var progresol = await _IRepositorioProgresol.ObtenerAsincronoPorCodigoLocal(pTiendaDto.DscCodLocalSap);

            if (progresol == null)
                throw new ProgresolExcepcionDominio(Mensajes.app_validacion_ProgresolInvalidoParaGenerarCompra); //poner Mensaje



            if (pTiendaDto.CondicionesDelivery != null)
            {
                        foreach (var item in pTiendaDto.CondicionesDelivery)
                        {
                            int lCodCondicionDelivery = Convert.ToInt32(item.CodCondicionDelivery);
                            _TiendacondicionDelivery = await _IRepositorioCondicionDelivery.ObtenerAsincronoPorId(lCodCondicionDelivery);
                         
                            if (_TiendacondicionDelivery == null)
                                throw new ProgresolExcepcionDominio(Mensajes.app_validacion_TiendaCondicionDelivery);
                        }
            }
            else
            {
                throw new ProgresolExcepcionDominio(Mensajes.app_validacion_TiendaCondicionDelivery);
            }


            if(pTiendaDto.ProductosDestacados!=null)
            {
                foreach (var item in pTiendaDto.ProductosDestacados)
                {
                    _ProductoDestacados = await _IRepositorioProductosDestacados.ObtenerAsincronoPorId(item.CodProductoDestacado);

                    if (_ProductoDestacados == null)
                        throw new ProgresolExcepcionDominio(Mensajes.app_validacion_TiendaSinProductosDestacados);
                }

            }
            else
            {
                throw new ProgresolExcepcionDominio(Mensajes.app_validacion_TiendaSinProductosDestacados);
            }


            //if (pTiendaDto. != null)
            //{
            //    if (pTiendaDto.TiendaTipoEntrega.Count > 0)
            //    {
            //        foreach (var item in pTiendaDto.TiendaTipoEntrega)
            //        {
            //            int lCodTipoEntrega = Convert.ToInt32(item.CodTipoEntrega);

            //            _TipoEntrega = await _IRepositorioTipoEntrega.ObtenerAsincronoPorId(lCodTipoEntrega);

            //            //poner Mensaje
            //            if (_TipoEntrega == null)
            //                throw new ProgresolExcepcionDominio(Mensajes.app_validacion_TipoProveedorExternoIncorrectoParaGenerarCompra);
            //        }
            //    }
            //}
            //else
            //{
            //    //Mensaje No tiene condicion delivery
            //    throw new ProgresolExcepcionDominio(Mensajes.app_validacion_CompraSinDetallesCompra);
            //}


            if (pTiendaDto.TiempoEntrega != null)
            {
                foreach (var item in pTiendaDto.TiempoEntrega)
                {

                    int lCodTiempoEntrega = Convert.ToInt32(item.CodTiempoEntrega);

                    _TiempoEntrega = await _IRepositorioTiempoEntrega.ObtenerAsincronoPorId(lCodTiempoEntrega);

                    //poner Mensaje
                    if (_TiempoEntrega == null)
                        throw new ProgresolExcepcionDominio(Mensajes.app_validacion_TiendaSinTiempoEntrega);
                }
               
            }
            else
            {
                //Mensaje No tiene condicion delivery
                throw new ProgresolExcepcionDominio(Mensajes.app_validacion_TiendaSinTiempoEntrega);
            }


            if (pTiendaDto.TipoPago != null)
            {
                foreach (var item in pTiendaDto.TipoPago)
                {
                    int lCodTipoPago = Convert.ToInt32(item.CodTipoPago);

                    _TipoPago = await _IRepositorioTipoPago.ObtenerAsincronoPorId(lCodTipoPago);

                    //poner Mensaje
                    if (_TipoPago == null)
                        throw new ProgresolExcepcionDominio(Mensajes.app_validacion_TiendaSinTipoDePago);
                }
            }
            else
            {
                //Mensaje No tiene condicion delivery
                throw new ProgresolExcepcionDominio(Mensajes.app_validacion_TiendaSinTipoDePago);
            }


            if (pTiendaDto.TiendaHorarioAtencion != null)
            {
                foreach (var item in pTiendaDto.TiendaHorarioAtencion)
                {
                    int lCodRangoDiaAtencion = Convert.ToInt32(item.CodRangoDiaAtencion);

                    var _RangoDiaAtencion = await _IRepositorioRangoDiaAtencion.ObtenerAsincronoPorId(lCodRangoDiaAtencion);

                
                    //poner Mensaje
                    if (_RangoDiaAtencion == null)
                        throw new ProgresolExcepcionDominio(Mensajes.app_validacion_TiendaSinRangoDiaAtencion);
                }
            }
            else
            {
                //Mensaje No tiene condicion delivery
                throw new ProgresolExcepcionDominio(Mensajes.app_validacion_TiendaSinRangoDiaAtencion);
            }


            var nuevaTienda = CrearNuevaTienda(pTiendaDto);
            await GrabarTienda(nuevaTienda);

            TiendaCreadaDto TiendaCreada = new TiendaCreadaDto()
            {
               Id= nuevaTienda.CodTiendaProgresol
            };

            return new ResultadoServicio<TiendaCreadaDto>(EnumTipoResultado.OK,
              Mensajes.app_informacion_CreacionNuevaTiendaOk,
              string.Empty, TiendaCreada, null);
         
        }
        private async Task<bool> GrabarTienda(TiendaProgresol pTienda)
        {
            if(pTienda==null)//cambiar mensaje
                throw new ArgumentNullException(Mensajes.app_excepcion_TiendaNuloParaRegistrarla);

            _IRepositorioTiendaProgresol.Agregar(pTienda);

            return await _IRepositorioTiendaProgresol.UnidadDeTrabajo.GrabarAsincronicamenteEntidad();

        }
        private  TiendaProgresol CrearNuevaTienda(TiendaDto pTiendaDto)
        {
            var NuevaTienda = FactoryTiendaProgresol.CrearTiendaProgresol(pTiendaDto);

            foreach (var item in pTiendaDto.TipoPago)
            {
                var NuevoTiendaTipoPago = NuevaTienda.AgregarTiendaTipoPago(item.CodTipoPago,NuevaTienda.CodTiendaProgresol);
            }
            foreach (var item in pTiendaDto.CondicionesDelivery)
            {
                var NuevaTiendaCondicionDelivery = NuevaTienda.AgregarTiendaCondicionDelivery(item.CodCondicionDelivery, NuevaTienda.CodTiendaProgresol,item.DscMontoMinimo);
            }

            foreach (var item in pTiendaDto.TiempoEntrega)
            {
                var NuevaTiempoEntrega = NuevaTienda.AgregarTiendaTiempoEntrega(NuevaTienda.CodTiendaProgresol, item.CodTiempoEntrega);
            }

            foreach (var item in pTiendaDto.ProductosDestacados)
            {
                var NuevoProductosDestacados = NuevaTienda.AgregarProductosDestacados(NuevaTienda.CodTiendaProgresol, item.CodProductoDestacado);
            }

            foreach (var item in pTiendaDto.TiendaHorarioAtencion)
            {
                var NuevoTiendaHorarioAtencion = NuevaTienda.AgregarHorarioAtencion(NuevaTienda.CodTiendaProgresol, item.CodRangoDiaAtencion, item.CodHoraInicio, item.CodHoraFin);
            }

            return NuevaTienda;
        }

        //private bool ActualizarTiendaProgresol(TiendaProgresol pTiendaProgresol)
        //{
        //    if (pTiendaProgresol == null)
        //        //mensaje poner
        //        throw new ArgumentNullException(Mensajes.app_excepcion_ProveedorNuloParaActualizarlo);

        //    _IRepositorioTiendaProgresol.Actualizar(pTiendaProgresol);

        //    return true;
        //}

        //private bool ActualizarRelacionProveedorMaterial(Proveedor pProveedor)
        //{
        //    if (pProveedor == null)
        //        throw new ArgumentNullException(Mensajes.app_excepcion_ProveedorNuloParaActualizarlo);

        //    _IRepositorioProveedor.Actualizar(pProveedor);

        //    return true;
        //}
        #endregion
    }
}
