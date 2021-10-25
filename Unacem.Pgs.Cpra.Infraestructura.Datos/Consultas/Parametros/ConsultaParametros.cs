using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ModeloVista<ZonificacionProgresolModeloVista>> ConsultarListadoZonificacionesProgresol()
        {
            try
            {
                return await ConsultarZonificacionProgresol();
            }
            catch (Exception ex)
            {
                RegistrarError(Mensajes.error_infraestructura_consultaZonificacionesConErrores, ex, "ConsultarListadoZonificacionesProgresol");

                return new ModeloVista<ZonificacionProgresolModeloVista>(
                    new ResultadoConsulta
                    {
                        CodigoResultado = EnumResultadoConsulta.ERROR,
                        DescripcionResultado = Mensajes.error_infraestructura_consultaZonificacionesConErrores
                    }, null, null);
            }
        }

        private async Task<ModeloVista<ZonificacionProgresolModeloVista>> ConsultarZonificacionProgresol()
        {
            using (var conexion = new SqlConnection(_cadenaConexion))
            {
                var resultado = await conexion.QueryAsync<dynamic>(
                                        @"SELECT	COD_ZONA                AS codigoZona,        
                                                    DSC_ZONA                AS descripcionZona,  
		                                            COD_TERRITORIO          AS codigoTerritorio, 
		                                            DSC_TERRITORIO          AS descripcionTerritorio, 
		                                            COD_SUB_TERRITORIO      AS codigoSubTerritorio, 
		                                            DSC_SUB_TERRITORIO      AS descripcionSubTerritorio
                                            FROM	PGSTB_TEMP_FUN_CLIENTESPS_SAP (NOLOCK)
                                            WHERE	NOT COD_ZONA        IS NULL 
		                                            AND LEN(COD_ZONA)	!= 0
		                                            AND DSC_FLAG_TIENDA = 'X'
                                            GROUP BY COD_ZONA, DSC_ZONA, COD_TERRITORIO, 
		                                            DSC_TERRITORIO, COD_SUB_TERRITORIO, DSC_SUB_TERRITORIO",
                    new { DSC_ACTIVO = EnumActividadEstado.Inactivo });

                var cantidadFilas = resultado != null ? resultado.AsList().Count : 0;
                return new ModeloVista<ZonificacionProgresolModeloVista>(
                    new ResultadoConsulta
                    {
                        CodigoResultado = cantidadFilas == 0 ? EnumResultadoConsulta.SINRESULTADO : EnumResultadoConsulta.OK,
                        DescripcionResultado = cantidadFilas == 0 ? Mensajes.informacion_infraestructura_consultaZonificacionesSinResultados :
                                                                                Mensajes.informacion_infraestructura_consultarZonificacionesConResultados,
                        TotalRegistros = cantidadFilas
                    }, null, MapeoZonificacionProgresol(resultado));
            }
        }

        public async Task<ModeloVista<UbigeosProgresolModeloVista>> ConsultarListadoUbigeosProgresol()
        {
            try
            {
                return await ConsultarUbigeosProgresol();
            }
            catch (Exception ex)
            {
                RegistrarError(Mensajes.error_infraestructura_consultaUbigeosProgresolConErrores, ex, "ConsultarListadoUbigeosProgresol");

                return new ModeloVista<UbigeosProgresolModeloVista>(
                    new ResultadoConsulta
                    {
                        CodigoResultado = EnumResultadoConsulta.ERROR,
                        DescripcionResultado = Mensajes.error_infraestructura_consultaUbigeosProgresolConErrores
                    }, null, null);
            }
        }

        private async Task<ModeloVista<UbigeosProgresolModeloVista>> ConsultarUbigeosProgresol()
        {
            using (var conexion = new SqlConnection(_cadenaConexion))
            {
                var resultado = await conexion.QueryAsync<dynamic>(
                                     @"SELECT   UBGPGS.codigoUbigeo
		                                        ,UBGPGS.codigoDepartamento
		                                        ,UBGPGS.departamento
		                                        ,UBGPGS.codigoProvincia
		                                        ,UBGPGS.provincia
		                                        ,UBGPGS.codigoDistrito
		                                        ,UBGPGS.distrito
                                        FROM	(	SELECT	'SNC'					AS codigoUbigeo
					                                        ,'CDEP'					AS codigoDepartamento 
					                                        ,DSC_DEPARTAMENTO		AS departamento 
					                                        ,'CPROV'				AS codigoProvincia
					                                        ,DSC_PROVINCIA			AS provincia
					                                        ,'CDIST'				AS codigoDistrito
					                                        ,DSC_DISTRITO			AS distrito
			                                        FROM	PGSTB_TEMP_FUN_CLIENTESPS_SAP (NOLOCK)
			                                        WHERE	DSC_FLAG_TIENDA		= @DSC_FLAG_TIENDA
			                                        GROUP BY DSC_DEPARTAMENTO
					                                        ,DSC_PROVINCIA
					                                        ,DSC_DISTRITO) UBGPGS
                                        WHERE	LEN(UBGPGS.provincia)		!= ''  
		                                        AND LEN(UBGPGS.distrito)	!= ''",
                    new { DSC_FLAG_TIENDA = EnumActivacionLocalProgesol.Activado});

                var cantidadFilas = resultado != null ? resultado.AsList().Count : 0;
                return new ModeloVista<UbigeosProgresolModeloVista>(
                    new ResultadoConsulta
                    {
                        CodigoResultado = cantidadFilas == 0 ? EnumResultadoConsulta.SINRESULTADO : EnumResultadoConsulta.OK,
                        DescripcionResultado = cantidadFilas == 0 ? Mensajes.informacion_infraestructura_consultaUbigeosProgresolSinResultados :
                                                                                Mensajes.informacion_infraestructura_consultarUbigeosProgresolConResultados,
                        TotalRegistros = cantidadFilas
                    }, null, MapeoUbigeosProgresol(resultado));
            }
        }

        private List<ZonificacionProgresolModeloVista> MapeoZonificacionProgresol(dynamic pResultadoZonificacion)
        {
            var zonificacionesProgresol = new List<ZonificacionProgresolModeloVista>();
            foreach (var zonificacion in pResultadoZonificacion)
            {
                bool existeTerritorio = false;
                bool existeZonificacionProgresol = false;

                var zonificacionProgresol = zonificacionesProgresol.FirstOrDefault(w => w.codigoZona == zonificacion.codigoZona);
                if (zonificacionProgresol == null)
                    zonificacionProgresol = new ZonificacionProgresolModeloVista
                    {
                        codigoZona = zonificacion.codigoZona,
                        descripcionZona = zonificacion.descripcionZona
                    };
                else
                    existeZonificacionProgresol = true;

                var territorio = zonificacionProgresol.territorios.FirstOrDefault(w => w.codigoTerritorio == zonificacion.codigoTerritorio);
                if (territorio == null)
                    territorio = new TerritorioProgresolModeloVista
                    {
                        codigoTerritorio = zonificacion.codigoTerritorio,
                        descripcionTerritorio = zonificacion.descripcionTerritorio,
                        codigoZona = zonificacion.codigoZona
                    };

                else
                    existeTerritorio = true;


                var subTerritorio = territorio.subTerritorios.FirstOrDefault(w => w.codigoSubTerritorio == zonificacion.codigoSubTerritorio);
                if (subTerritorio == null)
                    subTerritorio = new SubTerritorioProgresolModeloVista
                    {
                        codigoSubTerritorio = zonificacion.codigoSubTerritorio,
                        descripcionSubTerritorio = zonificacion.descripcionSubTerritorio,
                        codigoTerritorio = zonificacion.codigoTerritorio
                    };


                territorio.subTerritorios.Add(subTerritorio);

                if (!existeTerritorio)
                    zonificacionProgresol.territorios.Add(territorio);

                if (!existeZonificacionProgresol)
                    zonificacionesProgresol.Add(zonificacionProgresol);
            }


            return zonificacionesProgresol;
        }


        private List<UbigeosProgresolModeloVista> MapeoUbigeosProgresol(dynamic pResultadoUbigeos)
        {
            var departamentos = new List<UbigeosProgresolModeloVista>();
            foreach (var departamento in pResultadoUbigeos)
            {
                bool existeDepartamento = false;
                bool existeProvincia = false;

                var departamentoProgresol = departamentos.FirstOrDefault(w => w.departamento == departamento.departamento);
                if (departamentoProgresol == null)
                    departamentoProgresol = new UbigeosProgresolModeloVista
                    {
                        codigoDepartamento = departamento.codigoDepartamento,
                        departamento = departamento.departamento
                    };
                else
                    existeDepartamento = true;

                var provincia = departamentoProgresol.provincias.FirstOrDefault(w => w.provincia == departamento.provincia);
                if (provincia == null)
                    provincia = new ProvinciaProgresolModeloVista
                    {
                        codigoProvincia = departamento.codigoProvincia,
                        provincia = departamento.provincia,
                    };

                else
                    existeProvincia = true;


                var distrito = provincia.distritos.FirstOrDefault(w => w.distrito == departamento.distrito);
                if (distrito == null)
                    distrito = new DistritoProgresolModeloVista
                    {
                        codigoDistrito = departamento.codigoDistrito,
                        distrito = departamento.distrito,
                        codigoUbigeo = departamento.codigoUbigeo
                    };


                provincia.distritos.Add(distrito);

                if (!existeProvincia)
                    departamentoProgresol.provincias.Add(provincia);

                if (!existeDepartamento)
                    departamentos.Add(departamentoProgresol);
            }


            return departamentos;
        }

        private void RegistrarError(string pMensaje, Exception pException, params object[] pArgumentos)
        {
            LogFactory.CrearLog().LogError(pMensaje, pException, pArgumentos);
        }
    }
}
