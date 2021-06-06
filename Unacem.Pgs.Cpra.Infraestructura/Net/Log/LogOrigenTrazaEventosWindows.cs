using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security;
using System.Text;
using Unacem.Pgs.Infraestructura.Base;
using Unacem.Pgs.Infraestructura.Log;

namespace Unacem.Pgs.Cpra.Infraestructura.Net.Log
{
    public sealed class LogOrigenTrazaEventosWindows : ILog
    {
        ILoggerFactory _logFactory;
        ILogger _log;

        public LogOrigenTrazaEventosWindows()
        {
            _logFactory = new LoggerFactory(new[] { new EventLogLoggerProvider() });
            _log = _logFactory.CreateLogger("API Web UNACEM");
        }


        void SeguimientoInterno(int pLogNivel, string pMensaje)
        {
            try
            {
                if (_logFactory != null && _log != null)
                {
                    switch (pLogNivel)
                    {
                        case EnumLogNivel.Trace:
                            _log.LogTrace(new EventId(EnumLogNivel.Trace), pMensaje);
                            break;
                        case EnumLogNivel.Debug:
                            _log.LogDebug(new EventId(EnumLogNivel.Debug), pMensaje);
                            break;
                        case EnumLogNivel.Information:
                            _log.LogInformation(new EventId(EnumLogNivel.Information), pMensaje);
                            break;
                        case EnumLogNivel.Warning:
                            _log.LogWarning(new EventId(EnumLogNivel.Warning), pMensaje);
                            break;
                        case EnumLogNivel.Error:
                            _log.LogError(new EventId(EnumLogNivel.Error), pMensaje);
                            break;
                        case EnumLogNivel.Critical:
                            _log.LogCritical(new EventId(EnumLogNivel.Critical), pMensaje);
                            break;
                        default:
                            break;
                    }
                }

            }
            catch (SecurityException)
            {
                // No se puede acceder al archivo de escucha o no puede tener
                // privilegios para escribir en el registro de eventos etc .
            }
        }


        public void Debug(string mensaje, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                SeguimientoInterno(EnumLogNivel.Debug, mensajeDeSeguimiento);
            }
        }

        public void Debug(string mensaje, Exception excepcion, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje) && excepcion != null)
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                var dataExcepcion = excepcion.StackTrace;

                SeguimientoInterno(EnumLogNivel.Debug, string.Format(CultureInfo.InvariantCulture,
                    "{0} Excepcion:{1}", mensajeDeSeguimiento, dataExcepcion));
            }
        }

        public void Debug(object item)
        {
            if (item != null)
                SeguimientoInterno(EnumLogNivel.Debug, item.ToString());
        }

        public void Fatal(string mensaje, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                SeguimientoInterno(EnumLogNivel.Critical, mensajeDeSeguimiento);
            }
        }

        public void Fatal(string mensaje, Exception excepcion, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje) && excepcion != null)
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                var dataExcepcion = excepcion.StackTrace;

                SeguimientoInterno(EnumLogNivel.Critical, string.Format(CultureInfo.InvariantCulture,
                    "{0} Excepcion:{1}", mensajeDeSeguimiento, dataExcepcion));

            }
        }

        public void LogError(string mensaje, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                SeguimientoInterno(EnumLogNivel.Error, mensajeDeSeguimiento);
            }
        }

        public void LogError(string mensaje, Exception excepcion, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje) && excepcion != null)
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);
                var dataExcepcion = excepcion.ToString();

                SeguimientoInterno(EnumLogNivel.Error, string.Format(CultureInfo.InvariantCulture,
                    "{0} Excepcion:{1}", mensajeDeSeguimiento, dataExcepcion));
            }
        }

        public void LogInfo(string mensaje, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                SeguimientoInterno(EnumLogNivel.Information, mensajeDeSeguimiento);
            }
        }

        public void LogWarning(string mensaje, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                SeguimientoInterno(EnumLogNivel.Warning, mensajeDeSeguimiento);
            }
        }
    }
}
