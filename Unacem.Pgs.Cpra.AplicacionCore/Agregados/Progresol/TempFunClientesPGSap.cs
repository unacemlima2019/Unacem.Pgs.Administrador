using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Progresol
{
    public class TempFunClientesPGSap
    {
        //public PgstbTempFunClientespsSap()
        //{
        //    PgstbCompraMinorista = new HashSet<PgstbCompraMinorista>();
        //    PgstbCuotaLocal = new HashSet<PgstbCuotaLocal>();
        //}
        public TempFunClientesPGSap()
        {

        }

        public TempFunClientesPGSap(int pCodClientepsSap,string pCodPadre,string pCodHijo,string pLongitud,string pLatitud,string pNombreComercial,string pCelularDueno,string pDireccion,string pCodPdv,string pFlagTienda,string pLogoTienda,string pHoraAtencion,string pProvincia,string pDistrito,string pDepartamento,string pTipoProgresol,string pRazonSocial,string PRucCliente,string pCodZona,string pDescZona,string pCodTerritorio,string pDescTerritorio,string pCodSubTerritorio,string pDescSubTerritorio)
        {
            _CodClientepsSap = pCodClientepsSap;
            _CodPadre = pCodPadre;
            _CodHijo = pCodHijo;
            _DscLongitud = pLongitud;
            _DscLatitud = pLatitud;
            _DscNombreComercial = pNombreComercial;
            _DscCelularDueno = pCelularDueno;
            _DscDireccion = pDireccion;
            _CodPdv = pCodPdv;
            _DscFlagTienda = pFlagTienda;
            _DscLogoTienda = pLogoTienda;
            _DscHorarioAtencion = pHoraAtencion;
            _DscProvincia = pProvincia;
            _DscDistrito = pDistrito;
            _DscDepartamento = pDepartamento;
            _DscTipoProgresol = pTipoProgresol;
            _DscRazonSocial = pRazonSocial;
            _DscRucCliente = PRucCliente;
            _CodZona = pCodZona;
            _DscZona = pDescZona;
            _CodTerritorio = pCodTerritorio;
            _DscTerritorio = pDescTerritorio;
            _CodSubTerritorio = pCodSubTerritorio;
            _DscSubTerritorio = pDescSubTerritorio;
        }
        public int CodClientepsSap => _CodClientepsSap;
        private int _CodClientepsSap;

        public string CodPadre => _CodPadre;
        private string _CodPadre;

        public string CodHijo => _CodHijo;
        private string _CodHijo;

        public string DscLongitud => _DscLongitud;
        private string _DscLongitud;

        public string DscLatitud => _DscLatitud;
        private string _DscLatitud;

        public string DscNombreComercial => _DscNombreComercial;
        private string _DscNombreComercial;

        public string DscCelularDueno => _DscCelularDueno;
        private string _DscCelularDueno;

        public string DscDireccion => _DscDireccion;
        private string _DscDireccion;

        public string CodPdv => _CodPdv;
        private string _CodPdv;

        public string DscFlagTienda => _DscFlagTienda;
        private string _DscFlagTienda;

        public string DscLogoTienda => _DscLogoTienda;
        private string _DscLogoTienda;

        public string DscHorarioAtencion => _DscHorarioAtencion;
        private string _DscHorarioAtencion;

        public string DscProvincia => _DscProvincia;
        private string _DscProvincia;

        public string DscDistrito => _DscDistrito;
        private string _DscDistrito;

        public string DscDepartamento => _DscDepartamento;
        private string _DscDepartamento;

        public string DscTipoProgresol => _DscTipoProgresol;
        private string _DscTipoProgresol;

        public string DscRazonSocial => _DscRazonSocial;
        private string _DscRazonSocial;

        public string DscRucCliente => _DscRucCliente;
        private string _DscRucCliente;

        public string CodZona => _CodZona;
        private string _CodZona;

        public string DscZona => _DscZona;
        private string _DscZona;

        public string CodTerritorio => _CodTerritorio;
        private string _CodTerritorio;

        public string DscTerritorio => _DscTerritorio;
        private string _DscTerritorio;

        public string CodSubTerritorio => _CodSubTerritorio;
        private string _CodSubTerritorio;

        public string DscSubTerritorio => _DscSubTerritorio;
        private string _DscSubTerritorio;

        //public virtual ICollection<PgstbCompraMinorista> PgstbCompraMinorista { get; set; }
        //public virtual ICollection<PgstbCuotaLocal> PgstbCuotaLocal { get; set; }
    }
}
