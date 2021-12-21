using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Recursos;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.AplicacionCore.Excepciones;
using Unacem.Pgs.Cpra.AplicacionCore.Base;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Materiales
{
    public class UsoMaterial : Entidad
    {
        public Guid CodigoUso => _codigoUso;
        private Guid _codigoUso;
        public Guid CodigoMaterial => _codigoMaterial;
        private Guid _codigoMaterial;

        public string DetalleUsoMaterial => _detalleUsoMaterial;
        private string _detalleUsoMaterial;
        public string Activo => _activo;
        private string _activo;

        public virtual Uso Uso { get; private set; }
        public UsoMaterial() { }

        public UsoMaterial(Guid pCodigoUso, Guid pCodigoMaterial,
                          string pDetalleUsoMaterial)
        {
            if (pCodigoUso == Guid.Empty)
                throw new ProgresolExcepcionDominio(Mensajes.dominio_validacion_CodigoUsoDeUsoMaterialInvalido);

            if (pCodigoMaterial == Guid.Empty)
                throw new ProgresolExcepcionDominio(Mensajes.dominio_validacion_CodigoMaterialDeUsoMaterialInvalido);

            _codigoUso = pCodigoUso;
            _codigoMaterial = pCodigoMaterial;
            _detalleUsoMaterial = pDetalleUsoMaterial;

            GenerarNuevaIdentidad();
            Activar();
        }

        public void EstablecerUsoDeUsoMaterial(Uso pUso)
        {
            Uso = pUso;
            _codigoUso = pUso.Id;
        }
        public void Activar()
        {
            _activo = EnumActivacion.Activado;
        }
    }
}
