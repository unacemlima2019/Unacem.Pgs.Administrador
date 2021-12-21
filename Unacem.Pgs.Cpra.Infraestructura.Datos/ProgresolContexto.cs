using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Materiales;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Progresol;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;
using Unacem.Pgs.Admin.Infraestructura.Datos.ConfiguracionesEntidad;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda;
using Unacem.Pgs.Cpra.Infraestructura.Datos.ConfiguracionesEntidad;


namespace Unacem.Pgs.Cpra.Infraestructura.Datos
{
    public class ProgresolContexto : DbContext, IUnidadDeTrabajo
    {
        public const string DEFAULT_SCHEMA = "dbo";

        public DbSet<Progresol> Progresoles { get; set; } 
        public DbSet<ProductoDestacados> ProductoDestacados { get; set; }
        public DbSet<CondicionesDelivery> CondicionDelivery { get; set; }
        public DbSet<TiendaCondicionDelivery> TiendaCondicionDelivery { get; set; }
        public DbSet<TipoEntrega> TipoEntrega { get; set; }
        public DbSet<TiempoEntrega> TiempoEntrega { get; set; }
        public DbSet<TipoPago> TipoPago { get; set; }
        public DbSet<TiendaProgresol> TiendaProgresol { get; set; }
        public DbSet<TiendaTipoPago> TiendaTipoPago { get; set; }
        public DbSet<TiendaTiempoEntrega> TiendaTiempoEntrega { get; set; }
        public DbSet<TiendaProductoDestacados> TiendaProductoDestacados { get; set; }
        public DbSet<TiendaHorarioAtencion> TiendaHorarioAtencion { get; set; }
        public DbSet<RangoDiaAtencion> RangoDiaAtencion { get; set; }
        //public DbSet<TempFunClientesPGSap> TempFunClientesPGSap { get; set; }

        public DbSet<Uso> Usos { get; set; }
        public DbSet<UsoMaterial> UsoMateriales { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }
        public DbSet<CaracteristicaMaterial> CaracteristicaMateriales { get; set; }

        public DbSet<Material> Materiales { get; set; }

        public ProgresolContexto(DbContextOptions<ProgresolContexto> opciones) : base(opciones) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
   
            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadProgresol());       
            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadTienda());
            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadCondicionesDelivery());
            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadProductosDestacados());
            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadTiempoEntrega());
            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadTipoPago());
            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadTiendaTipoPago());
            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadTiendaCondicionesDelivery());
            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadTiendaTiempoEntrega());
            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadTiendaProductosDestacados());
            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadTiendaHorarioAtencion());
            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadRangoDiaAtencion());
            //modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadTempFunClientesPGSap());

            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadUso());
            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadCaracteristica());
            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadUsoMaterial());
            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadCaracteristicaMaterial());

            modelBuilder.ApplyConfiguration(new ConfiguracionTipoEntidadMaterial());
        }

        public async Task<bool> GrabarAsincronicamenteEntidad(CancellationToken tokenDeCancelacion = default(CancellationToken))
        {
            var resultado = await base.SaveChangesAsync();

            return true;
        }

        //public bool GrabarEntidad()
        //{
        //    var resultado = base.SaveChanges();

        //    return true;
        //}
    }

    public class DisenioProgresolContextoFactory : IDesignTimeDbContextFactory<ProgresolContexto>
    {
        public ProgresolContexto CreateDbContext(string[] args)
        {
            var creaOpciones = new DbContextOptionsBuilder<ProgresolContexto>()
                .UseSqlServer(@"Server=DESKTOP-59INEGQ\SQLEXPRESS;Initial Catalog=PGS_TESTS;User Id=sa;Password=!sql2019;");

            return new ProgresolContexto(creaOpciones.Options);
        }
    }
}
