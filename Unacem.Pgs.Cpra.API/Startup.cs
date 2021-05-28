using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Unacem.Pgs.Cpra.API.Infraestructura.IoC;
using Unacem.Pgs.Cpra.Infraestructura.Datos;
using Unacem.Pgs.Cpra.API.Infraestructura.Seguridad;

namespace Unacem.Pgs.Cpra.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {            
            services.AddControllers();
            //services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));


            services.AddCustomMvc()
                    .AddCustomDbContext(Configuration)
                    .AddCustomSwagger(Configuration);

            //configure autofac
            var container = new ContainerBuilder();
            container.Populate(services);
            container.RegisterModule(new ModuloAplicacion(Configuration));

            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservicio Administrador Tienda V1");
            });

            app.UseRouting();
            app.UseMiddleware<ValidacionJwtMiddleware>();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
                   .AddDbContext<ProgresolContexto>(options =>
                   {
                       options.UseSqlServer(configuration["ConnectionString"],
                           sqlServerOptionsAction: sqlOptions =>
                           {
                               sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                               sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                               sqlOptions.MaxBatchSize(1);
                               //sqlOptions.UseRowNumberForPaging();
                           });
                   },
                       ServiceLifetime.Scoped  //Mostrar explícitamente que DbContext se comparte en el alcance de la solicitud HTTP (gráfico de objetos iniciados en la solicitud HTTP)
                   );

            return services;
        }

        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            // Agregar servicios framework.
            services.AddMvc(options => { }).AddControllersAsServices();  //Inyección de controladores a través de DI


            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";
                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Administrador Tienda {groupName}",
                    Version = groupName,
                    Description = "APIs Administrador Tienda",
                    Contact = new OpenApiContact
                    {
                        Name = "Progresol",
                        Email = string.Empty,
                        Url = new Uri("https://progresol.com/"),
                    }
                });
            });

            return services;
        }
    }
}
