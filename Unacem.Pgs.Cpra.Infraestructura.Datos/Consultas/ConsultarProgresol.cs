﻿using Dapper;
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
                                            @"SELECT	SA.DSC_RUC_CLIENTE			AS RucCliente,
		                                                SA.COD_PDV					AS CodPdv,
		                                                SA.DSC_NOMBRE_COMERCIAL		as NombreComercial,
		                                                PG.DSC_CELULAR				AS Celular,
		                                                SA.DSC_DIRECCION			AS Direccion,
		                                                SA.DSC_LONGITUD				AS Latitud,
		                                                SA.DSC_LATITUD				AS Longitud,
		                                                SA.COD_ZONA					AS CodZona,
		                                                SA.DSC_ZONA					AS Zona,
		                                                SA.COD_TERRITORIO			AS CodTerritorio,
		                                                SA.DSC_TERRITORIO			AS Territorio,
		                                                SA.COD_SUB_TERRITORIO		AS CodSubTerritorio,
		                                                SA.DSC_SUB_TERRITORIO		AS SubTerritorio,
		                                                ''							AS Usuario,
		                                                SA.DSC_FLAG_TIENDA			AS FlagTienda,
		                                                SA.DSC_TIPO_PROGRESOL		AS TipoProgresol,
                                                        case  
                                                            when SA.DSC_FLAG_TIENDA <> 'X' then 'No Tienda'      
                                                            when pg.COD_TIENDA_PROGRESOL is null AND SA.DSC_FLAG_TIENDA = 'X' then 'Pendiente'          
                                                        else 'En Linea'
                                                        end							as Accion,
                                                        pg.COD_TIENDA_PROGRESOL		AS CodTiendaProgresol
                                                FROM	[PGS].[dbo].[PGSTB_TEMP_FUN_CLIENTESPS_SAP] (nolock) SA
		                                                LEFT join [dbo].[PGSTB_TIENDA_PROGRESOL]	(nolock) PG	on sa.COD_PDV	=	PG.DSC_COD_LOCAL_SAP
                                                group by SA.DSC_RUC_CLIENTE,
		                                                SA.COD_PDV,
		                                                SA.DSC_DIRECCION,
		                                                SA.DSC_NOMBRE_COMERCIAL,
		                                                SA.COD_ZONA,
		                                                SA.DSC_ZONA,
		                                                SA.COD_TERRITORIO,
		                                                SA.DSC_TERRITORIO,
		                                                SA.COD_SUB_TERRITORIO,
		                                                SA.DSC_SUB_TERRITORIO,
		                                                pg.COD_TIENDA_PROGRESOL,
		                                                pg.COD_TIENDA_PROGRESOL,
		                                                PG.DSC_CELULAR,
		                                                SA.DSC_FLAG_TIENDA,
		                                                SA.DSC_LONGITUD,
		                                                SA.DSC_LATITUD,
		                                                SA.DSC_TIPO_PROGRESOL
                                                order by codpdv");

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
