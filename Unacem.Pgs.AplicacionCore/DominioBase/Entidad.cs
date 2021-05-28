using System;
using System.Collections.Generic;
using System.Text;

namespace Unacem.Pgs.AplicacionCore.DominioBase
{
    public abstract class Entidad
    {
        int? _pedirCodigoHash;
        Guid _Id;
        public virtual Guid Id
        {
            get
            {

                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }


        public bool EsTransitorio()
        {
            return this.Id == Guid.Empty;
        }

        public void GenerarNuevaIdentidad()
        {
            if (EsTransitorio())
                this.Id = GeneradorIdentidad.NuevaGuidSecuencial();
        }

        public void CambiarIdentidadActual(Guid identidad)
        {
            if (identidad != Guid.Empty)
                this.Id = identidad;
        }



        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entidad))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entidad elemento = (Entidad)obj;

            if (elemento.EsTransitorio() || this.EsTransitorio())
                return false;
            else
                return elemento.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!EsTransitorio())
            {
                if (!_pedirCodigoHash.HasValue)
                    _pedirCodigoHash = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _pedirCodigoHash.Value;
            }
            else
                return base.GetHashCode();

        }
        public static bool operator ==(Entidad izquierda, Entidad derecha)
        {
            if (Object.Equals(izquierda, null))
                return (Object.Equals(derecha, null)) ? true : false;
            else
                return izquierda.Equals(derecha);
        }

        public static bool operator !=(Entidad izquierda, Entidad derecha)
        {
            return !(izquierda == derecha);
        }
    }
}
