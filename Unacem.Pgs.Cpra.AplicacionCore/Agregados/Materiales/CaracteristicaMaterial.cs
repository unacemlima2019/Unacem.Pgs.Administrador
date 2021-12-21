using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Recursos;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.AplicacionCore.Excepciones;
using Unacem.Pgs.Cpra.AplicacionCore.Base;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Materiales
{
    public class CaracteristicaMaterial : Entidad
    {
        public Guid CodigoCaracteristica => _codigoCaracteristica;
        private Guid _codigoCaracteristica;
        public Guid CodigoMaterial => _codigoMaterial;
        private Guid _codigoMaterial;

        public string DetalleCaracteristicaMaterial => _detalleCaracteristicaMaterial;
        private string _detalleCaracteristicaMaterial;
        public string Activo => _activo;
        private string _activo;

        public virtual Caracteristica Caracteristica { get; private set; }

        public CaracteristicaMaterial() { }


        public CaracteristicaMaterial(Guid pCodigoCaracteristica, Guid pCodigoMaterial, 
                                      string pDetalleCaracteristicaMaterial)
        {
            if (pCodigoCaracteristica == Guid.Empty)
                throw new ProgresolExcepcionDominio(Mensajes.dominio_validacion_CodigoCaracteristicaDeCaracteristicaMaterialInvalido);

            if (pCodigoMaterial == Guid.Empty)
                throw new ProgresolExcepcionDominio(Mensajes.dominio_validacion_CodigoMaterialDeCaracteristicaMaterialInvalido);

            _codigoCaracteristica = pCodigoCaracteristica;
            _codigoMaterial = pCodigoMaterial;
            _detalleCaracteristicaMaterial = pDetalleCaracteristicaMaterial;

            this.GenerarNuevaIdentidad();
            Activar();
        }

        public void EstablecerCaracteristicaDeCaracteristicaMaterial(Caracteristica pCaracteristica)
        {
            this.Caracteristica = pCaracteristica;
            this._codigoCaracteristica = pCaracteristica.Id;
        }
        public void Activar()
        {
            _activo = EnumActivacion.Activado;
        }
    }
}
