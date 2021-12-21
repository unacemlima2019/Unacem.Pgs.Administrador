using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Recursos;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.AplicacionCore.Excepciones;
using Unacem.Pgs.Cpra.AplicacionCore.Base;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Materiales
{
    public class Caracteristica : Entidad, IRaizAgregado
    {
        public string CodigoCaracteristicaSap { get; private set; }
        public string DescripcionCaracteristica => _descripcionCaracteristica;
        private string _descripcionCaracteristica;
        public string Activo => _activo;
        private string _activo;

        private readonly List<CaracteristicaMaterial> _caracteristicaMateriales;
        public IReadOnlyCollection<CaracteristicaMaterial> CaracteristicaMateriales => _caracteristicaMateriales;

        public bool EsActivo()
        {
            return this._activo == EnumActivacion.Activado;
        }

        protected Caracteristica()
        {
            _caracteristicaMateriales = new List<CaracteristicaMaterial>();
        }

        public Caracteristica(string pCodigoCaracteristicaSap, string pDescripcionCaracteristica) : this()
        {
            if (string.IsNullOrEmpty(pDescripcionCaracteristica))
                throw new ProgresolExcepcionDominio(Mensajes.dominio_validacion_DescripcionCaracteristicaDeCaracteristicaNuloOVacio);

            this.CodigoCaracteristicaSap = pCodigoCaracteristicaSap;

            _descripcionCaracteristica = pDescripcionCaracteristica;

            this.GenerarNuevaIdentidad();
            Activar();
        }

        public CaracteristicaMaterial AgregarCaracteristicaMaterial(Guid pCodigoMaterial, string pDetalleCaracteristicaMaterial)
        {
            var nuevaCaracteristicaMaterial = new CaracteristicaMaterial(this.Id, pCodigoMaterial, pDetalleCaracteristicaMaterial);

            _caracteristicaMateriales.Add(nuevaCaracteristicaMaterial);

            return nuevaCaracteristicaMaterial;
        }
        public void Activar()
        {
            _activo = EnumActivacion.Activado;
        }
    }
}
