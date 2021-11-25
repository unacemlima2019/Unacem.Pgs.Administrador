﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Admin.Infraestructura.Datos.Consultas.Parametros
{
    public class TipoUsuarioCotizacionListadoModeloVista
    {
        public Guid id { get; set; }
        public string descripcionTipoUsuarioCotizacion { get; set; }
    }

    public class TipoCotizacionListadoModeloVista
    {
        public Guid id { get; set; }
        public string descripcionTipoCotizacion { get; set; }
        public string abreviaturaTipoCotizacion { get; set; }

    }

    public class ZonificacionProgresolModeloVista
    {
        public string codigoZona { get; set; }
        public string descripcionZona { get; set; }
        public List<TerritorioProgresolModeloVista> territorios { get; set; }

        public ZonificacionProgresolModeloVista()
        {
            territorios = new List<TerritorioProgresolModeloVista>();
        }
    }

    public class TerritorioProgresolModeloVista
    {
        public string codigoTerritorio { get; set; }
        public string descripcionTerritorio { get; set; }
        public string codigoZona { get; set; }
        public List<SubTerritorioProgresolModeloVista> subTerritorios { get; set; }

        public TerritorioProgresolModeloVista()
        {
            subTerritorios = new List<SubTerritorioProgresolModeloVista>();
        }
    }

    public class SubTerritorioProgresolModeloVista
    {
        public string codigoSubTerritorio { get; set; }
        public string descripcionSubTerritorio { get; set; }
        public string codigoTerritorio { get; set; }
    }

    public class UbigeosProgresolModeloVista
    {
        public string codigoDepartamento { get; set; }
        public string departamento { get; set; }

        public List<ProvinciaProgresolModeloVista> provincias { get; set; }


        public UbigeosProgresolModeloVista()
        {
            provincias = new List<ProvinciaProgresolModeloVista>();
        }
    }

    public class ProvinciaProgresolModeloVista
    {
        public string codigoProvincia { get; set; }
        public string provincia { get; set; }

        public List<DistritoProgresolModeloVista> distritos { get; set; }

        public ProvinciaProgresolModeloVista()
        {
            distritos = new List<DistritoProgresolModeloVista>();
        }
    }

    public class DistritoProgresolModeloVista
    {
        public string codigoDistrito { get; set; }
        public string distrito { get; set; }

        public string codigoUbigeo { get; set; }       
    }

}
