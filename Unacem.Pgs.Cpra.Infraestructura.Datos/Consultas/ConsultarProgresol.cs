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
                                         SA.DSC_RUC_CLIENTE AS RucCliente,
	                                     SA.COD_PDV AS CodPdv,
	                                    case 
	                                    when SA.DSC_NOMBRE_COMERCIAL is null or trim(SA.DSC_NOMBRE_COMERCIAL)='' then
	                                    SA.DSC_RAZON_SOCIAL
	                                    else
	                                    SA.DSC_NOMBRE_COMERCIAL
	                                    end as NombreComercial,
	                                     SA.DSC_DIRECCION AS Direccion,
	                                     SA.COD_ZONA AS CodZona,
	                                     SA.DSC_ZONA AS Zona,
	                                     SA.COD_TERRITORIO AS CodTerritorio,
                                         SA.DSC_TERRITORIO AS Territorio,
	                                     SA.COD_SUB_TERRITORIO AS CodSubTerritorio,
                                         SA.DSC_SUB_TERRITORIO AS SubTerritorio,
	                                     US.COD_USUARIO AS Usuario,
	                                     case  
	                                     when (select count(*) from [dbo].[PGSTB_TIENDA_PROGRESOL] PG
			                                     where PG.DSC_COD_LOCAL_SAP=SA.COD_PDV) > 0 then

                                        'En Linea'
	                                    else
	                                    'Pendiente'
	                                    end as Accion
                                      FROM [PGS].[dbo].[PGSTB_TEMP_FUN_CLIENTESPS_SAP] SA
                                        LEFT join [dbo].[SEGTB_USUARIO] US
                                        on sa.DSC_RUC_CLIENTE=US.NUM_DOCUMENTO
                                      order by COD_PADRE");

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
