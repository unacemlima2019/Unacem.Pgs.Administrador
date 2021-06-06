using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.Admin.Infraestructura.Datos.Recursos;
using Unacem.Pgs.Infraestructura.Datos.ConsultasBase;
using Unacem.Pgs.Infraestructura.Log;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.Consultas
{
    public class ConsultarProgresol: IConsultarProgresol
    {
        private string _cadenaConexion = string.Empty;

        public ConsultarProgresol(string pCadenaConexion)
        {
            _cadenaConexion = !string.IsNullOrWhiteSpace(pCadenaConexion) ?
                    pCadenaConexion : throw new ArgumentNullException(nameof(pCadenaConexion));
        }

        public async Task<ModeloVista<ModeloVistaProgresol>> ConsultaDatosProgresol()
        {
            try
            {
                return await ConsultarInformacionProgresol();
            }
            catch (Exception ex)
            {
                RegistrarError(Mensajes.error_App_ConsultaProgresolSinResultados, ex, "ConsultaDatosProgresol");

                return new ModeloVista<ModeloVistaProgresol>(
                    new ResultadoConsulta
                    {
                        CodigoResultado = EnumResultadoConsulta.ERROR,
                        DescripcionResultado = Mensajes.error_App_ConsultaProgresolSinResultados
                    }, null, null);
            }
        }

        private async Task<ModeloVista<ModeloVistaProgresol>> ConsultarInformacionProgresol()
        {
            using (var conexion = new SqlConnection(_cadenaConexion))
            {
                var resultado = await conexion.QueryAsync<ModeloVistaProgresol>(
                                        @"SELECT 
                                             DSC_RUC_CLIENTE AS RucCliente,
	                                         COD_PDV AS CodPdv,
	                                         'activo' AS Estado,
	                                        case 
	                                         when DSC_NOMBRE_COMERCIAL is null or trim(DSC_NOMBRE_COMERCIAL)='' then
	                                           DSC_RAZON_SOCIAL
	                                        else
	                                            DSC_NOMBRE_COMERCIAL
	                                        end as NombreComercial,
	                                         DSC_DIRECCION AS Direccion,
	                                         COD_ZONA AS CodZona,
	                                         DSC_ZONA AS Zona,
	                                         COD_TERRITORIO AS CodTerritorio,
                                             DSC_TERRITORIO AS Territorio,
	                                         COD_SUB_TERRITORIO AS CodSubTerritorio,
                                             DSC_SUB_TERRITORIO AS SubTerritorio,
	                                         'Admin' AS Usuario,
	                                         'Alta' AS Accion,
	                                         'Activo' AS EnPgsCom
                                          FROM [PGS].[dbo].[PGSTB_TEMP_FUN_CLIENTESPS_SAP]");

                return new ModeloVista<ModeloVistaProgresol>(
                    new ResultadoConsulta
                    {
                        CodigoResultado = EnumResultadoConsulta.OK,
                        DescripcionResultado = Mensajes.error_App_ConsultaProgresolConResultados,
                        TotalRegistros = resultado.AsList().Count
                    }, null, resultado);
            }
        }

        private void RegistrarError(string pMensaje, Exception pException, params object[] pArgumentos)
        {
            LogFactory.CrearLog().LogError(pMensaje, pException, pArgumentos);
        }

    }
}
