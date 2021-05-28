using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.Cpra.AplicacionCore.Base;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda
{
    public class Progresol: IRaizAgregado
    {
        public int CorrelativoCliente { get; private set; }
        public string CodigoProgresolSap { get; private set; }
        public string CodigoProgresolHijoSap { get; private set; }
        public string Longitud { get; private set; }
        public string Latitud { get; private set; }
        public string NombreComercial { get; private set; }
        public string CelularDueño { get; private set; }
        public string Direccion { get; private set; }
        public string CodigoLocalProgresolSap { get; private set; }  //CodPdv(COD_PDV)
        public string FlagTienda { get; private set; }
        public string LogoTienda { get; private set; }
        public string HorarioAtencion { get; private set; }
        public string Provincia { get; private set; }
        public string Distrito { get; private set; }
        public string Departamento { get; private set; }
        public string TipoProgresol { get; private set; }
        public string NombreORazonSocialProgresol { get; private set; }
        //public bool EsActualizableSaldosCuota { get; private set; }
        //public string Activo { get; private set; }

        public Progresol() { }

        public bool EsActivo()
        {
            return this.FlagTienda == EnumActivacionLocalProgesol.Activado;
        }

    }
}
