
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Unacem.Pgs.Infraestructura.Adaptador;

namespace Unacem.Pgs.Cpra.Infraestructura.Net.Adaptador
{
    public class AutomapperTipoAdaptadorFactory : ITipoAdaptadorFactory
    {
        public AutomapperTipoAdaptadorFactory()
        {
            var profiles = AppDomain.CurrentDomain
                                    .GetAssemblies()
                                    .SelectMany(a => a.GetTypes())
                                    .Where(t => t.BaseType == typeof(Profile));

            Mapper.Initialize(cfg =>
            {
                foreach (var item in profiles)
                {
                    if (item.FullName != "AutoMapper.SelfProfiler`2")
                        cfg.AddProfile(Activator.CreateInstance(item) as Profile);
                }
            });
        }

        public ITipoAdaptador Crear()
        {
            return new AutomapperTipoAdaptador();
        }
    }
}
