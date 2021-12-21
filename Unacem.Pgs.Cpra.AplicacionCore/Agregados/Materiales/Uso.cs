using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Recursos;
using Unacem.Pgs.AplicacionCore.DominioBase;
using Unacem.Pgs.AplicacionCore.Excepciones;
using Unacem.Pgs.Cpra.AplicacionCore.Base;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Materiales
{
    public class Uso : Entidad, IRaizAgregado
    {
        public string CodigoUsoSap { get; private set; }
        public string DescripcionUso => _descripcionUso;
        private string _descripcionUso;
        public string Activo => _activo;
        private string _activo;

        private readonly List<UsoMaterial> _usoMateriales;
        public IReadOnlyCollection<UsoMaterial> UsoMateriales => _usoMateriales;

        public bool EsActivo()
        {
            return _activo == EnumActivacion.Activado;
        }

        protected Uso()
        {
            _usoMateriales = new List<UsoMaterial>();
        }

        public Uso(string pCodigoUsoSap, string pDescripcionUso) : this()
        {
            if (string.IsNullOrEmpty(pDescripcionUso))
                throw new ProgresolExcepcionDominio(Mensajes.dominio_validacion_DescripcionUsoDeUsoNuloOVacio);

            CodigoUsoSap = pCodigoUsoSap;

            _descripcionUso = pDescripcionUso;

            GenerarNuevaIdentidad();
            Activar();
        }

        public UsoMaterial AgregarUsoMaterial(Guid pCodigoMaterial, string pDetalleUsoMaterial)
        {
            var nuevoUsoMaterial = new UsoMaterial(Id, pCodigoMaterial, pDetalleUsoMaterial);

            _usoMateriales.Add(nuevoUsoMaterial);

            return nuevoUsoMaterial;
        }

        public void Activar()
        {
            _activo = EnumActivacion.Activado;
        }
    }
}
