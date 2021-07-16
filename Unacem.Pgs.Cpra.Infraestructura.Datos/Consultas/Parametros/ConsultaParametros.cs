using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unacem.Pgs.Admin.Infraestructura.Datos.Base;
using Unacem.Pgs.Admin.Infraestructura.Datos.Recursos;
using Unacem.Pgs.Infraestructura.Datos.ConsultasBase;
using Unacem.Pgs.Infraestructura.Log;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.Consultas.Parametros
{
    public class ConsultaParametros : IConsultaParametros
    {
        private string _cadenaConexion = string.Empty;

        public ConsultaParametros(string pCadenaConexion)
        {
            _cadenaConexion = !string.IsNullOrWhiteSpace(pCadenaConexion) ?
                    pCadenaConexion : throw new ArgumentNullException(nameof(pCadenaConexion));
        }


        public async Task<ModeloVista<TipoUsuarioCotizacionListadoModeloVista>> ConsultarListadoTiposUsuarioCotizacion()
        {
            try
            {
                return await ConsultarTiposUsuarioCotizacion();
            }
            catch (Exception ex)
            {
                RegistrarError(Mensajes.error_infraestructura_consultaTiposUsuarioCotizacionConErrores, ex, "ConsultarListadoTiposUsuarioCotizacion");

                return new ModeloVista<TipoUsuarioCotizacionListadoModeloVista>(
                    new ResultadoConsulta
                    {
                        CodigoResultado = EnumResultadoConsulta.ERROR,
                        DescripcionResultado = Mensajes.error_infraestructura_consultaTiposUsuarioCotizacionConErrores
                    }, null, null);
            }
        }

        private async Task<ModeloVista<TipoUsuarioCotizacionListadoModeloVista>> ConsultarTiposUsuarioCotizacion()
        {
            using (var conexion = new SqlConnection(_cadenaConexion))
            {
                var resultado = await conexion.QueryAsync<TipoUsuarioCotizacionListadoModeloVista>(
                                        @"SELECT	 COD_TIPO_USUARIO_COTIZACION    AS id
                                                    ,DSC_TIPO_USUARIO_COTIZACION    AS descripcionTipoUsuarioCotizacion
                                            FROM	dbo.PGSTB_TIPO_USUARIO_COTIZACION (NOLOCK)
                                            WHERE	FLAG_ACTIVO  != @DSC_ACTIVO",
                    new {DSC_ACTIVO = EnumActividadEstado.Inactivo });

                var cantidadFilas = resultado != null ? resultado.AsList().Count : 0;
                return new ModeloVista<TipoUsuarioCotizacionListadoModeloVista>(
                    new ResultadoConsulta
                    {
                        CodigoResultado = cantidadFilas == 0 ? EnumResultadoConsulta.SINRESULTADO : EnumResultadoConsulta.OK,
                        DescripcionResultado = cantidadFilas == 0 ? Mensajes.informacion_infraestructura_consultaTiposUsuarioCotizacionSinResultados :
                                                                                Mensajes.informacion_infraestructura_consultarTiposUsuarioCotizacionConResultados,
                        TotalRegistros = cantidadFilas
                    }, null, resultado);
            }
        }

        public async Task<ModeloVista<TipoCotizacionListadoModeloVista>> ConsultarListadoTiposCotizacion()
        {
            try
            {
                return await ConsultarTiposCotizacion();
            }
            catch (Exception ex)
            {
                RegistrarError(Mensajes.error_infraestructura_consultaTiposCotizacionConErrores, ex, "ConsultarListadoTiposCotizacion");

                return new ModeloVista<TipoCotizacionListadoModeloVista>(
                    new ResultadoConsulta
                    {
                        CodigoResultado = EnumResultadoConsulta.ERROR,
                        DescripcionResultado = Mensajes.error_infraestructura_consultaTiposCotizacionConErrores
                    }, null, null);
            }
        }

        private async Task<ModeloVista<TipoCotizacionListadoModeloVista>> ConsultarTiposCotizacion()
        {
            using (var conexion = new SqlConnection(_cadenaConexion))
            {
                var resultado = await conexion.QueryAsync<TipoCotizacionListadoModeloVista>(
                                        @"SELECT	 COD_TIPO_COTIZACION        AS id
                                                    ,DSC_TIPO_COTIZACION        AS descripcionTipoCotizacion
                                                    ,DSC_ABREV_TIPO_COTIZACION  AS abreviaturaTipoCotizacion
                                            FROM	dbo.PGSTB_TIPO_COTIZACION (NOLOCK)
                                            WHERE	FLAG_ACTIVO  != @DSC_ACTIVO",
                    new { DSC_ACTIVO = EnumActividadEstado.Inactivo });

                var cantidadFilas = resultado != null ? resultado.AsList().Count : 0;
                return new ModeloVista<TipoCotizacionListadoModeloVista>(
                    new ResultadoConsulta
                    {
                        CodigoResultado = cantidadFilas == 0 ? EnumResultadoConsulta.SINRESULTADO : EnumResultadoConsulta.OK,
                        DescripcionResultado = cantidadFilas == 0 ? Mensajes.informacion_infraestructura_consultaTiposCotizacionSinResultados :
                                                                                Mensajes.informacion_infraestructura_consultarTiposCotizacionConResultados,
                        TotalRegistros = cantidadFilas
                    }, null, resultado);
            }
        }

        private void RegistrarError(string pMensaje, Exception pException, params object[] pArgumentos)
        {
            LogFactory.CrearLog().LogError(pMensaje, pException, pArgumentos);
        }

    }
}
