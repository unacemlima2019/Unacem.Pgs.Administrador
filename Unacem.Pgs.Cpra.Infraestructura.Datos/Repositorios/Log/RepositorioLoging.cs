using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Unacem.Pgs.AplicacionCore.Log;

namespace Unacem.Pgs.Cpra.Infraestructura.Datos.Repositorios.Log
{
    public class RepositorioLoging : IRepositorioLoging
    {
        private string _cadenaConexion = string.Empty;

        public RepositorioLoging(string pCadenaConexion)
        {
            _cadenaConexion = !string.IsNullOrWhiteSpace(pCadenaConexion) ?
                    pCadenaConexion : throw new ArgumentNullException(nameof(pCadenaConexion));
        }

        public bool Agregar(Loging pLog)
        {
            var filasAfectadas = 0;
            using (IDbConnection cn = new SqlConnection(_cadenaConexion))
            {
                string sqlAgregaLog = @"INSERT INTO dbo.GRLTB_APP_ERROR(COD_APP, NUM_TICKET, COD_USUARIO, COD_ERROR, DSC_ERROR, FCH_ERROR, DSC_ERROR_DET) 
                                                            VALUES
                                                            (@COD_APP, @NUM_TICKET, @COD_USUARIO, @COD_ERROR, @DSC_ERROR, @FCH_ERROR, @DSC_ERROR_DET)";

                filasAfectadas = cn.Execute(sqlAgregaLog, new
                {
                    COD_APP = pLog.CodigoAplicacion,
                    NUM_TICKET = pLog.NumeroTicket,
                    COD_USUARIO = pLog.CodigoUsuario,
                    COD_ERROR = pLog.CodigoError,   
                    DSC_ERROR = pLog.DescripcionError,
                    FCH_ERROR = pLog.FechaError,
                    DSC_ERROR_DET = pLog.DetalleError
                });
            }

            return filasAfectadas == 0 ? false : true;
        }
    }
}
