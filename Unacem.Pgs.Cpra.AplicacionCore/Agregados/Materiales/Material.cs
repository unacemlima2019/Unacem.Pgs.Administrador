using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.AplicacionCore.DominioBase;

namespace Unacem.Pgs.Admin.AplicacionCore.Agregados.Materiales
{
    public class Material : Entidad, IRaizAgregado
    {
        public string CodigoProductoSap { get; private set; }
        public string Sku { get; private set; }
        public string NombreMaterial { get; private set; }
        public string NombreMaterialParser { get; private set; }

        public string RutaImagen { get; private set; }
        public string UsuarioCreacion { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public string UsuarioActualizacion { get; private set; }
        public DateTime FechaActualizacion { get; private set; }
        public decimal OrdenMaterial { get; private set; }
        public string Activo { get; private set; }

        public Guid CodigoCategoria { get; private set; }
        public Guid CodigoTipo { get; private set; }
        public Guid CodigoMarca { get; private set; }
        public Guid CodigoUnidadMedida { get; private set; }

        //public virtual Categoria Categoria { get; private set; }

        public Material() { }
    }
}
