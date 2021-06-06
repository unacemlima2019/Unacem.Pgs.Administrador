using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Unacem.Pgs.AplicacionCore.Log;
using Unacem.Pgs.Cpra.Infraestructura.Base;
using Unacem.Pgs.Infraestructura.Archivos;
using Unacem.Pgs.Infraestructura.Base;
using Unacem.Pgs.Infraestructura.Log;

namespace Unacem.Pgs.Cpra.Infraestructura.Net.Log
{
    public sealed class LogOrigenTrazaBaseDatos : ILog
    {
        private readonly IRepositorioLoging _IRepositorioLog;
        private string _rutaLog;
        private string _nombreArchivoLog;
        private string _extensionArchivoLog;

        public LogOrigenTrazaBaseDatos(IRepositorioLoging pIRepositorioLog, ConfiguracionAplicacion pConfiguracionAplicacion)
        {
            this._IRepositorioLog = pIRepositorioLog;
            this._rutaLog = pConfiguracionAplicacion.RutaLog;
            this._nombreArchivoLog = pConfiguracionAplicacion.NombreArchivoLog;
            this._extensionArchivoLog = pConfiguracionAplicacion.ExtensionArchivoLog;
        }

        void SeguimientoInterno(int pLogNivel, int pCodigoError, string pMensaje, string pDetalleMensaje)
        {
            try
            {
                RegistrarLogEnBaseDeDatos(pCodigoError, pMensaje, pDetalleMensaje);
            }
            catch (Exception ex)
            {
                RegistrarLogEnArchivo(pMensaje, pDetalleMensaje);
            }
        }

        private void RegistrarLogEnArchivo(string pMensaje, string pDetalleMensaje)
        {
            var filasContenidoLog = new List<string>() 
            {
                "\r\nRegistro Log : ",
                string.Format(CultureInfo.InvariantCulture, "Fecha Hora Error: {0} {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString()),
                string.Format(CultureInfo.InvariantCulture, "Error :{0}", pMensaje),
                string.Format(CultureInfo.InvariantCulture, "Detalles Error :{0}", pDetalleMensaje),
                "------------------------------------------------"
            };

            ArchivoFactory.CrearArchivo().EsccribirArchivoAdjuntandoTexto(filasContenidoLog, _rutaLog, 
                                                                            _nombreArchivoLog, _extensionArchivoLog);
        }

        private void RegistrarLogEnBaseDeDatos(int pCodigoError, string pMensaje, string pDetalleMensaje)
        {
            if (NoEsPosiblePersistirLog(pMensaje))
                throw new ArgumentException("No es posible persistir el Log. Es necesario inicializar un repositorio, configuracion de la aplicacion y un tener un log a persistir.");

            _IRepositorioLog.Agregar(new Loging(EnumCodigoAplicacion.PgsMsAdminTiendas,
                                                    DateTime.Now.ToString("yyyyMMddHHmmss"),
                                                    EnumUsuarioDefault.PgsPublico,
                                                    pCodigoError,
                                                    pMensaje,
                                                    DateTime.Now,
                                                    pDetalleMensaje));
        }

        private bool NoEsPosiblePersistirLog(string pMensaje)
        {
            return _IRepositorioLog == null || string.IsNullOrEmpty(pMensaje);
        }

        public void Debug(string mensaje, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                SeguimientoInterno(EnumLogNivel.Debug, EnumCodigoErrorDefault.DebugSinExcepcion, mensaje, mensajeDeSeguimiento);
            }
        }

        public void Debug(string mensaje, Exception excepcion, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje) && excepcion != null)
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);
                var dataExcepcion = excepcion.ToString();

                SeguimientoInterno(EnumLogNivel.Debug, EnumCodigoErrorDefault.DebugConExcepcion, mensaje, string.Format(CultureInfo.InvariantCulture,
                    "{0} Excepcion:{1}", mensajeDeSeguimiento, dataExcepcion));
            }
        }

        public void Debug(object item)
        {
            if (item != null)
                SeguimientoInterno(EnumLogNivel.Debug, EnumCodigoErrorDefault.Debug, item.ToString(), string.Empty);
        }

        public void Fatal(string mensaje, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                SeguimientoInterno(EnumLogNivel.Critical, EnumCodigoErrorDefault.FatalSinExcepcion, mensaje, mensajeDeSeguimiento);
            }
        }

        public void Fatal(string mensaje, Exception excepcion, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje) && excepcion != null)
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);
                var dataExcepcion = excepcion.ToString();

                SeguimientoInterno(EnumLogNivel.Critical, EnumCodigoErrorDefault.FatalSinExcepcion, mensaje, string.Format(CultureInfo.InvariantCulture,
                    "{0} Excepcion:{1}", mensajeDeSeguimiento, dataExcepcion));

            }
        }

        public void LogError(string mensaje, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                SeguimientoInterno(EnumLogNivel.Error, EnumCodigoErrorDefault.LogErrorSinExcepcion, mensaje, mensajeDeSeguimiento);
            }
        }

        public void LogError(string mensaje, Exception excepcion, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje) && excepcion != null)
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);
                var dataExcepcion = excepcion.ToString();

                SeguimientoInterno(EnumLogNivel.Error, excepcion.HResult, mensaje,  string.Format(CultureInfo.InvariantCulture,
                    "{0} Excepcion:{1}", mensajeDeSeguimiento, dataExcepcion));
            }
        }

        public void LogInfo(string mensaje, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                SeguimientoInterno(EnumLogNivel.Information, EnumCodigoErrorDefault.LogInfo, mensaje, mensajeDeSeguimiento);
            }
        }

        public void LogWarning(string mensaje, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                SeguimientoInterno(EnumLogNivel.Warning, EnumCodigoErrorDefault.LogWarning, mensaje, mensajeDeSeguimiento);
            }
        }
    }
}
