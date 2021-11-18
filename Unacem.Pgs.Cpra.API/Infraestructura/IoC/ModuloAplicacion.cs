using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Configuration;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Videos;
using Unacem.Pgs.Admin.AplicacionCore.Servicios.Aplicacion;
using Unacem.Pgs.Admin.Infraestructura.Datos.Consultas;
using Unacem.Pgs.Admin.Infraestructura.Datos.Consultas.Parametros;
using Unacem.Pgs.Admin.Infraestructura.Datos.Repositorios.Tienda;
using Unacem.Pgs.Admin.Infraestructura.Datos.Repositorios.Videos;
using Unacem.Pgs.Cpra.Infraestructura.Base;

using Unacem.Pgs.Cpra.Infraestructura.Datos.Repositorios.Log;
using Unacem.Pgs.Cpra.Infraestructura.Net.Adaptador;
using Unacem.Pgs.Cpra.Infraestructura.Net.Archivos;
using Unacem.Pgs.Cpra.Infraestructura.Net.Log;
using Unacem.Pgs.Infraestructura.Adaptador;
using Unacem.Pgs.Infraestructura.Archivos;

using Unacem.Pgs.Infraestructura.Log;

namespace Unacem.Pgs.Cpra.API.Infraestructura.IoC
{
    public class ModuloAplicacion : Autofac.Module
    {
        private ConfiguracionAplicacion _configuracionAplicacion;

        public string CadenaConexionConsultas { get; }

        public ModuloAplicacion(IConfiguration pIConfiguration)
        {

            this.CadenaConexionConsultas = pIConfiguration["ConnectionString"];

            _configuracionAplicacion = new ConfiguracionAplicacion
            {
                CadenaConexion = pIConfiguration["ConnectionString"],
                RutaLog = pIConfiguration["RutaLog"],
                NombreArchivoLog = pIConfiguration["NombreArchivoLog"],
                ExtensionArchivoLog = pIConfiguration["ExtensionArchivoLog"]
                //InfoEnvioCorreo = new InfoEnvioCorreo
                //{
                //    mailusr = pIConfiguration.GetValue<string>("InfoEnvioCorreo:mailusr"),
                //    mailpsw = pIConfiguration.GetValue<string>("InfoEnvioCorreo:mailpsw"),
                //    mailport = pIConfiguration.GetValue<string>("InfoEnvioCorreo:mailport"),
                //    mailsubject = pIConfiguration.GetValue<string>("InfoEnvioCorreo:mailsubject"),
                //    maildom = pIConfiguration.GetValue<string>("InfoEnvioCorreo:maildom"),
                //    mailhost = pIConfiguration.GetValue<string>("InfoEnvioCorreo:mailhost"),
                //    mailsender = pIConfiguration.GetValue<string>("InfoEnvioCorreo:mailsender"),
                //    mailsenderCCO = pIConfiguration.GetValue<string>("InfoEnvioCorreo:mailsenderCCO"),
                //    mailsenderCC = pIConfiguration.GetValue<string>("InfoEnvioCorreo:mailsenderCC"),
                //    mailTest = pIConfiguration.GetValue<string>("InfoEnvioCorreo:mailTest"),
                //    lnkRecuperarCuenta = pIConfiguration.GetValue<string>("InfoEnvioCorreo:lnkRecuperarCuenta"),
                //}
            };
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ConsultarProgresol(CadenaConexionConsultas))
              .As<IConsultarProgresol>()
              .InstancePerLifetimeScope();

            builder.Register(c => new ConsultaParametros(CadenaConexionConsultas))
              .As<IConsultaParametros>()
              .InstancePerLifetimeScope();

            //Repositorios
            builder.RegisterType<RepositorioProgresol>()
                .As<IRepositorioProgresol>()
                .InstancePerLifetimeScope();


            builder.RegisterType<RepositorioTiendaProgresol>()
               .As<IRepositorioTiendaProgresol>()
               .InstancePerLifetimeScope();


            builder.RegisterType<RepositorioCondicionDelivery>()
              .As<IRepositorioCondicionDelivery>()
              .InstancePerLifetimeScope();


            builder.RegisterType<RepositorioProductosDestacados>()
             .As<IRepositorioProductosDestacados>()
             .InstancePerLifetimeScope();

            builder.RegisterType<RepositorioTipoEntrega>()
             .As<IRepositorioTipoEntrega>()
             .InstancePerLifetimeScope();

            builder.RegisterType<RepositorioTiempoEntrega>()
            .As<IRepositorioTiempoEntrega>()
            .InstancePerLifetimeScope();

            builder.RegisterType<RepositorioTipoPago>()
           .As<IRepositorioTipoPago>()
           .InstancePerLifetimeScope();

            builder.RegisterType<RepositorioTiendaProgresol>()
            .As<IRepositorioTiendaProgresol>()
            .InstancePerLifetimeScope();

            builder.RegisterType<RepositorioRangoDiaAtencion>()
            .As<IRepositorioRangoDiaAtencion>()
            .InstancePerLifetimeScope();


            builder.RegisterType<RepositorioRangoDiaAtencion>()
            .As<IRepositorioRangoDiaAtencion>()
            .InstancePerLifetimeScope();




            builder.RegisterType<RepositorioVideo>()
            .As<IRepositorioVideo>()
            .InstancePerLifetimeScope();

            builder.RegisterType<RepositorioTipoVideo>()
            .As<IRepositorioTipoVideo>()
            .InstancePerLifetimeScope();
            

            //Servicios App

            builder.RegisterType<ServicioAplicacionTienda>()
                .As<IServicioAplicacionTienda>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ServicioAplicacionVideo>()
               .As<IServicioAplicacionVideo>()
               .InstancePerLifetimeScope();


            //Abstract Factory
            ArchivoFactory.EstablecerArchivoFactory(new ArchivoFuenteFactory());
            LogFactory.EstablecerActual(new LogOrigenTrazaPersisitenciaFactory(
                                          new RepositorioLoging(_configuracionAplicacion.CadenaConexion), _configuracionAplicacion));
            //TipoAdaptadorFactory.EstablecerActual(new AutomapperTipoAdaptadorFactory());

        }
    }
}
