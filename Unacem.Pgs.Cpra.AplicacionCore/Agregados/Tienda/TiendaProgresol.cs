using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Recursos;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.AplicacionCore.Excepciones;
using Unacem.Pgs.Cpra.AplicacionCore.Base;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
    public class TiendaProgresol : IRaizAgregado
    {
        public int CodTiendaProgresol { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string CodLocalSap => _CodLocalSap;
        private string _CodLocalSap;

        public string FotoAvatar => _FotoAvatar;
        private string _FotoAvatar;

        public byte[] ImagenAvatar => _ImagenAvatar;
        private byte[] _ImagenAvatar;

        public string HorarioAtencion => _HorarioAtencion;

        private string _HorarioAtencion;

        public string Celular => _Celular;
        private string _Celular;

        public string CelularOpcional => _CelularOpcional;
        private string _CelularOpcional;

        public string Negocio => _Negocio;
        private string _Negocio;

        public string Activo => _Activo;
        private string _Activo;

        public string UsuarioCreacion => _UsuarioCreacion;
        private string _UsuarioCreacion;

        public DateTime FechaCreacion => _FechaCreacion;
        private DateTime _FechaCreacion;
        public string NombreComercialCorto => _NombreComercialCorto;
        private string _NombreComercialCorto;
        //public virtual TiendaTipoPago _TipoPago { get; private set; }

        private readonly List<TiendaTipoPago> _TiendaTipoPago;
        public IReadOnlyCollection<TiendaTipoPago> TiendaTipoPago => _TiendaTipoPago;


        private readonly List<TiendaCondicionDelivery> _TiendaCondicionDelivery;
        public IReadOnlyCollection<TiendaCondicionDelivery> TiendaCondicionDelivery => _TiendaCondicionDelivery;


        private readonly List<TiendaTiempoEntrega> _TiendaTiempoEntrega;
        public IReadOnlyCollection<TiendaTiempoEntrega> TiendaTiempoEntrega => _TiendaTiempoEntrega;


        private readonly List<TiendaProductoDestacados> _TiendaProductosDestacados;
        public IReadOnlyCollection<TiendaProductoDestacados> TiendaProductosDestacados => _TiendaProductosDestacados;


        private readonly List<TiendaHorarioAtencion> _TiendaHorarioAtencion;
        public virtual IReadOnlyCollection<TiendaHorarioAtencion> TiendaHorarioAtencion => _TiendaHorarioAtencion;

        public TiendaProgresol(string CodLocalSap, string FotoAvatar, byte[] ImagenAvatar, string HorarioAtencion,
            string Celular, string CelularOpcional, string Negocio, string NombreComercialCorto,
            DateTime FechaCreacion, string UsuarioCreacion
            )
        {
            _CodLocalSap = CodLocalSap;
            _FotoAvatar = FotoAvatar;
            _ImagenAvatar = ImagenAvatar;
            _HorarioAtencion = HorarioAtencion;
            _Celular = Celular;
            _CelularOpcional = CelularOpcional;
            _Negocio = Negocio;
            _NombreComercialCorto = NombreComercialCorto;
            _FechaCreacion = FechaCreacion;
            _UsuarioCreacion = UsuarioCreacion;
            _TiendaTipoPago = new List<TiendaTipoPago>();
            _TiendaCondicionDelivery = new List<TiendaCondicionDelivery>();
            _TiendaTiempoEntrega = new List<TiendaTiempoEntrega>();
            _TiendaProductosDestacados = new List<TiendaProductoDestacados>();
            _TiendaHorarioAtencion = new List<TiendaHorarioAtencion>();
        }

        public void Activar()
        {
            _Activo = EnumActivacion.Activado;
        }

        public TiendaTipoPago AgregarTiendaTipoPago(int pCodTipoPago, int pCodProgresol)
        {
            var nuevoTipoPago = new TiendaTipoPago(pCodTipoPago, pCodProgresol);

            _TiendaTipoPago.Add(nuevoTipoPago);

            return nuevoTipoPago;
        }

        public TiendaCondicionDelivery AgregarTiendaCondicionDelivery(int pCodCondicionDelivery, int pCodProgresol, string pMontoMinimo)
        {
            var NuevoCondicionDelivery = new TiendaCondicionDelivery(pCodCondicionDelivery, pCodProgresol, pMontoMinimo);

            _TiendaCondicionDelivery.Add(NuevoCondicionDelivery);

            return NuevoCondicionDelivery;
        }

        public TiendaTiempoEntrega AgregarTiendaTiempoEntrega(int pCodTiendaProgresol, int pCodTiempoEntrega)
        {
            var NuevoTiempoEntrega = new TiendaTiempoEntrega(pCodTiendaProgresol, pCodTiempoEntrega);

            _TiendaTiempoEntrega.Add(NuevoTiempoEntrega);

            return NuevoTiempoEntrega;
        }

        public TiendaProductoDestacados AgregarProductosDestacados(int codTiendaProgresol, int codProductoDestacado)
        {
            var NuevaTiendaProductoDestacados = new TiendaProductoDestacados(codTiendaProgresol, codProductoDestacado);

            _TiendaProductosDestacados.Add(NuevaTiendaProductoDestacados);
            return NuevaTiendaProductoDestacados;
        }

        public TiendaHorarioAtencion AgregarHorarioAtencion(int codTiendaProgresol, int codRangoDiaAtencion, int codHoraInicio, int codHoraFin)
        {
            var NuevaTiendaHorarioAtencion = new TiendaHorarioAtencion(codTiendaProgresol, codRangoDiaAtencion, codHoraInicio, codHoraFin);
            _TiendaHorarioAtencion.Add(NuevaTiendaHorarioAtencion);
            return NuevaTiendaHorarioAtencion;
        }

        public void EstablecerCelular(string pNumeroCelular)
        {
            _Celular = pNumeroCelular;
        }
        public void EstablecerCodigoSap(string pCodLocalSap)
        {
            _CodLocalSap = pCodLocalSap;
        }
        public void EstablecerFotoAvatar(string pFotoAvatar)
        {
            _FotoAvatar = pFotoAvatar;
        }
        public void EstablecerImagenAvatar(byte[] pImagenAvatar)
        {
            _ImagenAvatar = pImagenAvatar;
        }
        public void EstablecerHorarioAtencion(string pHorarioAtencion)
        {
            _HorarioAtencion = pHorarioAtencion;
        }
        public void EstablecerCelularOpcional(string pCelularOpcional)
        {
            _CelularOpcional = pCelularOpcional;
        }
        public void EstablecerNegocio(string pNegocio)
        {
            _Negocio = pNegocio;
        }
        public void EstablecerNombreComercialCorto(string pNombreComercialCorto)
        {
            _NombreComercialCorto = pNombreComercialCorto;
        }

        public void QuitarTodosTipoPago()
        {
            _TiendaTipoPago.RemoveAll(s => s.CodTiendaProgresol == this.CodTiendaProgresol);
        }
        public void QuitarTodosCondicionDelivery()
        {
            _TiendaCondicionDelivery.RemoveAll(s => s.CodTiendaProgresol == this.CodTiendaProgresol);
        }
        public void QuitarTodosTiempoEntrega()
        {
            _TiendaTiempoEntrega.RemoveAll(s => s.CodTiendaProgresol == this.CodTiendaProgresol);
        }

        public void QuitarTodosProductosDestacados()
        {
            _TiendaProductosDestacados.RemoveAll(s => s.CodTiendaProgresol == this.CodTiendaProgresol);
        }

        public void QuitarTodosHorarioAtencion()
        {
            _TiendaHorarioAtencion.RemoveAll(s => s.CodTiendaProgresol == this.CodTiendaProgresol);
        }

        //public void EstablecerHorarioAtencion(TiendaHorarioAtencion pTiendaHorarioAtencion)
        //{
        //    if (pTiendaHorarioAtencion == null) //cambiar mensaje
        //        throw new ArgumentNullException(Mensajes.app_excepcion_ProveedorNuloParaActualizarlo);

        //    this.TiendaHorarioAtencion = pTiendaHorarioAtencion;

        //    //_codigoProveedor = TiendaHorarioAtencion.CodTiendaProgresol;
        //}


        //public TiendaHorarioAtencion TiendaHorarioAtencion(int codTiendaProgresol, int codTiendaHorarioAtencion, int codRangoDiaAtencion, int codHoraInicio, int codHoraFin)
        //{
        //    var NuevoHorarioAtencion = new TiendaHorarioAtencion(codTiendaProgresol, codTiendaHorarioAtencion, codRangoDiaAtencion, codHoraInicio, codHoraFin);

        //    //_TiendaHorarioAtencion = NuevoHorarioAtencion;
        //    return NuevoHorarioAtencion;
        //    //throw new NotImplementedException();
        //}
    }
}
