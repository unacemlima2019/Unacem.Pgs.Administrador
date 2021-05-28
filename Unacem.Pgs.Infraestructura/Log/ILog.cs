using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Infraestructura.Log
{
    public interface ILog
    {
        void Debug(string mensaje, params object[] argumentos);
        void Debug(string mensaje, Exception excepcion, params object[] argumentos);
        void Debug(object item);
        void Fatal(string mensaje, params object[] argumentos);
        void Fatal(string mensaje, Exception excepcion, params object[] argumentos);
        void LogInfo(string mensaje, params object[] argumentos);
        void LogWarning(string mensaje, params object[] argumentos);
        void LogError(string mensaje, params object[] argumentos);
        void LogError(string mensaje, Exception excepcion, params object[] argumentos);
    }
}
