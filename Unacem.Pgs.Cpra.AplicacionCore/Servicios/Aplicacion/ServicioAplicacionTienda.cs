using System;
using System.Collections.Generic;
using System.Linq;
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
        private TiendaProgresol _TiendaProgresol;
        private RangoDiaAtencion _RangoDiaAtencion;
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
        public async Task<ResultadoServicio<TiendaDto>> ConsultarTienda()
        {
            try
            {
                return await RecuperarTiendaPorDefecto();
            }
            catch (Exception ex)
            {
                Comun.RegistrarError(Mensajes.app_error_CreacionNuevaTiendaFallo, ex, "AgregarCompra");

                return new ResultadoServicio<TiendaDto>(EnumTipoResultado.ERROR,
                             Mensajes.app_error_CreacionNuevaTiendaFallo,
                             ex.Message, null, null);
            }
        }

        private async Task<ResultadoServicio<TiendaDto>> RecuperarTiendaPorDefecto()
        {
            TiendaDto oTienda = new TiendaDto();
            List<CondicionesDeliveryDto> oCondicionDelivery = new List<CondicionesDeliveryDto>();
            List<ProductoDestacadoDto> oProductosDestacados = new List<ProductoDestacadoDto>();
            List<TiempoEntregaDto> oTiempoEntrega = new List<TiempoEntregaDto>();
            List<TipoPagoDto> oTipoPago = new List<TipoPagoDto>();
            List<TiendaHorarioAtencionDto> oHorarioAtencion = new List<TiendaHorarioAtencionDto>();

            var ListTiendacondicionDelivery = await _IRepositorioCondicionDelivery.ObtenerAsincronoPorDefecto();
            if (ListTiendacondicionDelivery != null)
            {
                oCondicionDelivery = ListTiendacondicionDelivery.Select(e => new CondicionesDeliveryDto() {
                    CodCondicionDelivery = e.CodCondicionDelivery,
                    DscCondicionDelivery = e.DscCondicionDelivery,
                    DscActivo = e.DscActivo
                }).ToList();

                oTienda.CondicionesDelivery = new List<CondicionesDeliveryDto>();
                oTienda.CondicionesDelivery = oCondicionDelivery;
            }

            var ListProductosDestacados = await _IRepositorioProductosDestacados.ObtenerAsincronoPorDefecto();
            if (ListProductosDestacados != null)
            {
                oProductosDestacados = ListProductosDestacados.Select(e => new ProductoDestacadoDto()
                {
                    DscActivo = e.DscActivo,
                    DscCategoria = e.DscCategoria,
                    FchActualizacion = e.FchActualizacion,
                    CodProductoDestacado = e.CodProductoDestacado,
                    DscNombre = e.DscNombre,
                    DscRuta = e.DscRuta,
                    FchCreacion = e.FchCreacion
                }).ToList();

                oTienda.ProductosDestacados = new List<ProductoDestacadoDto>();
                oTienda.ProductosDestacados = oProductosDestacados;
            }

            var ListTiempoEntrega= await _IRepositorioTiempoEntrega.ObtenerAsincronoPorDefecto();
            if(ListTiempoEntrega!=null)
            {
                oTiempoEntrega = ListTiempoEntrega.Select(e => new TiempoEntregaDto()
                {
                    DscActivo=e.DscActivo,
                    CodTiempoEntrega=e.CodTiempoEntrega,
                    DscTiempoEntrega=e.DscTiempoEntrega
                }).ToList();


                oTienda.TiempoEntrega = new List<TiempoEntregaDto>();
                oTienda.TiempoEntrega = oTiempoEntrega;
            }

            var ListTipoPago = await _IRepositorioTipoPago.ObtenerAsincronoPorDefecto();
            if(ListTipoPago!=null)
            {
                oTipoPago = ListTipoPago.Select(e => new TipoPagoDto() 
                {
                    DscActivo=e.DscActivo,
                    CodTipoPago=e.CodTipoPago,
                    DscRutaLogo=e.DscRutaLogo,
                    DscTipoPago=e.DscTipoPago
                }).ToList();

                oTienda.TipoPago = new List<TipoPagoDto>();
                oTienda.TipoPago = oTipoPago;
            }
            var ListRangoDiaAtencion = await _IRepositorioRangoDiaAtencion.ObtenerAsincronoPorDefecto();
            if(ListRangoDiaAtencion!=null)
            {
                oHorarioAtencion = ListRangoDiaAtencion.Select(e => new TiendaHorarioAtencionDto() 
                { 
                    CodRangoDiaAtencion=e.CodRangoDiaAtencion,
                   CodHoraInicio=9,
                   CodHoraFin=7,
                }).ToList();


                oTienda.TiendaHorarioAtencion = new List<TiendaHorarioAtencionDto>();
                oTienda.TiendaHorarioAtencion = oHorarioAtencion;
            }
            

            return new ResultadoServicio<TiendaDto>(EnumTipoResultado.OK, Mensajes.app_informacion_DatosTiendaOk,
                    string.Empty, oTienda, null);

        }

        public async Task<ResultadoServicio<TiendaActualizadoDto>> ActualizadoTienda(TiendaDto pTiendaDto)
        {
            try
            {
                return await RegistrarActualizacionTienda(pTiendaDto);
            }
            catch (Exception ex)
            {

                Comun.RegistrarError(Mensajes.app_error_CreacionNuevaTiendaFallo, ex, "ActualizarTienda");

                return new ResultadoServicio<TiendaActualizadoDto>(EnumTipoResultado.ERROR,
                             Mensajes.app_error_CreacionNuevaTiendaFallo,
                             ex.Message, null, null);
            }
        }

        private async Task<ResultadoServicio<TiendaActualizadoDto>> RegistrarActualizacionTienda(TiendaDto pTiendaDto)
        {
            if(NoEsTiendaDtoValidaParaActualizarlo(pTiendaDto))
                throw new ArgumentException(Mensajes.app_error_CreacionNuevaTiendaFallo);

            _TiendaProgresol = await _IRepositorioTiendaProgresol.ObtenerAsincronoPorId(pTiendaDto.CodTiendaProgresol);
            if(_TiendaProgresol == null)
                throw new ArgumentException(Mensajes.app_error_CreacionNuevaTiendaFallo);




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


            if (pTiendaDto.ProductosDestacados != null)
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


            MaterializarPedidoDesdeDto(pTiendaDto);

           await ActualizarTiendaProgresol(_TiendaProgresol);

            TiendaActualizadoDto TiendaActualizado = new TiendaActualizadoDto()
            {
                Id =pTiendaDto.CodTiendaProgresol
            };


            return new ResultadoServicio<TiendaActualizadoDto>(EnumTipoResultado.OK, Mensajes.app_informacion_ActualizarTiendaOk,
                    string.Empty, TiendaActualizado, null);

        }

        private void  MaterializarPedidoDesdeDto(TiendaDto pTiendaDto)
        {
            _TiendaProgresol.EstablecerCelular(pTiendaDto.DscCelular);
            _TiendaProgresol.EstablecerCodigoSap(pTiendaDto.DscCodLocalSap);
            _TiendaProgresol.EstablecerFotoAvatar(pTiendaDto.DscFotoAvatar);
            _TiendaProgresol.EstablecerImagenAvatar(pTiendaDto.DscImagenAvatar);
            _TiendaProgresol.EstablecerHorarioAtencion(pTiendaDto.DscHorarioAtencion);
            _TiendaProgresol.EstablecerCelularOpcional(pTiendaDto.DscCelularOpcional);
            _TiendaProgresol.EstablecerNegocio(pTiendaDto.DscNegocio);
            _TiendaProgresol.EstablecerNombreComercialCorto(pTiendaDto.DscNombreComercialCorto);

            _TiendaProgresol.QuitarTodosTipoPago();

            foreach (var item in pTiendaDto.TipoPago)
            {
                var NuevoTiendaTipoPago = _TiendaProgresol.AgregarTiendaTipoPago(item.CodTipoPago, _TiendaProgresol.CodTiendaProgresol);
            }

            _TiendaProgresol.QuitarTodosCondicionDelivery();
            foreach (var item in pTiendaDto.CondicionesDelivery)
            {
                var NuevaTiendaCondicionDelivery = _TiendaProgresol.AgregarTiendaCondicionDelivery(item.CodCondicionDelivery, _TiendaProgresol.CodTiendaProgresol, item.DscMontoMinimo);
            }

            _TiendaProgresol.QuitarTodosTiempoEntrega();
            foreach (var item in pTiendaDto.TiempoEntrega)
            {
                var NuevaTiempoEntrega = _TiendaProgresol.AgregarTiendaTiempoEntrega(_TiendaProgresol.CodTiendaProgresol, item.CodTiempoEntrega);
            }

            _TiendaProgresol.QuitarTodosProductosDestacados();

            foreach (var item in pTiendaDto.ProductosDestacados)
            {
                var NuevoProductosDestacados = _TiendaProgresol.AgregarProductosDestacados(_TiendaProgresol.CodTiendaProgresol, item.CodProductoDestacado);
            }

            _TiendaProgresol.QuitarTodosHorarioAtencion();
            foreach (var item in pTiendaDto.TiendaHorarioAtencion)
            {
                var NuevoTiendaHorarioAtencion = _TiendaProgresol.AgregarHorarioAtencion(_TiendaProgresol.CodTiendaProgresol, item.CodRangoDiaAtencion, item.CodHoraInicio, item.CodHoraFin);
            }

            //throw new NotImplementedException();
        }

        private bool NoEsTiendaDtoValidaParaActualizarlo(TiendaDto pTiendaDto)
        {
            return pTiendaDto.CodTiendaProgresol == 0;
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
        private async Task<bool> ActualizarTiendaProgresol(TiendaProgresol pTienda)
        {
            if (pTienda == null)
                throw new ArgumentNullException(Mensajes.app_excepcion_TiendaNuloParaRegistrarla);

            _IRepositorioTiendaProgresol.Actualizar(pTienda);

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
