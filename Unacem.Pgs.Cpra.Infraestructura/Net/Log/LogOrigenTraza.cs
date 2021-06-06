using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Security;
using System.Text;
using Unacem.Pgs.Infraestructura.Log;

namespace Unacem.Pgs.Cpra.Infraestructura.Net.Log
{
    public sealed class LogOrigenTraza : ILog
    {
        TraceSource origen;

        //Crea una nueva instancia de este gestor de rastreo  
        public LogOrigenTraza()
        {
            //Crear origen predeterminado
            origen = new TraceSource("PuntoDeVentaApp");
        }

        //Traza mensaje interno de oyentes configurado
        //tipoEvento: Tipo de evento para rastrear
        //mensaje: Mensaje de evento
        void SeguimientoInterno(TraceEventType tipoEvento, string mensaje)
        {
            try
            {
                if (origen != null)
                {
                    origen.TraceEvent(tipoEvento, (int)tipoEvento, mensaje);
                }

            }
            catch (SecurityException)
            {
                // No se puede acceder al archivo de escucha o no puede tener
                // privilegios para escribir en el registro de eventos etc .
            }
        }


        public void LogInfo(string mensaje, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                SeguimientoInterno(TraceEventType.Information, mensajeDeSeguimiento);
            }
        }

        public void LogWarning(string mensaje, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                SeguimientoInterno(TraceEventType.Warning, mensajeDeSeguimiento);
            }
        }

        public void LogError(string mensaje, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                SeguimientoInterno(TraceEventType.Error, mensajeDeSeguimiento);
            }
        }

        public void LogError(string mensaje, Exception excepcion, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje) && excepcion != null)
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                var dataExcepcion = excepcion.StackTrace.ToString(); //El ToString () crear una representación de cadena de la excepción actual

                SeguimientoInterno(TraceEventType.Error, string.Format(CultureInfo.InvariantCulture,
                    "{0} Excepcion:{1}", mensajeDeSeguimiento, dataExcepcion));
            }
        }



        public void Debug(string mensaje, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                SeguimientoInterno(TraceEventType.Verbose, mensajeDeSeguimiento);
            }
        }

        public void Debug(string mensaje, Exception excepcion, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje) && excepcion != null)
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                var dataExcepcion = excepcion.ToString(); //El ToString () crear una representación de cadena de la excepción actual

                SeguimientoInterno(TraceEventType.Error, string.Format(CultureInfo.InvariantCulture,
                    "{0} Excepcion:{1}", mensajeDeSeguimiento, dataExcepcion));
            }
        }

        public void Debug(object item)
        {
            if (item != null)
            {
                SeguimientoInterno(TraceEventType.Verbose, item.ToString());
            }
        }

        public void Fatal(string mensaje, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje))
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                SeguimientoInterno(TraceEventType.Critical, mensajeDeSeguimiento);
            }
        }

        public void Fatal(string mensaje, Exception excepcion, params object[] argumentos)
        {
            if (!String.IsNullOrWhiteSpace(mensaje) && excepcion != null)
            {
                var mensajeDeSeguimiento = string.Format(CultureInfo.InvariantCulture, mensaje, argumentos);

                var dataExcepcion = excepcion.ToString();  //El ToString () crear una representación de cadena de la excepción actual

                SeguimientoInterno(TraceEventType.Critical, string.Format(CultureInfo.InvariantCulture,
                    "{0} Excepcion:{1}", mensajeDeSeguimiento, dataExcepcion));

            }
        }
    }
}
