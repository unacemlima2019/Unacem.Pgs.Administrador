using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Dto.Tienda;

namespace Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda
{
    public class TiendaDto
    {
        public int CodTiendaProgresol { get; set; }
        public string DscCodLocalSap { get; set; }
        public string DscFotoAvatar { get; set; }
        public byte[]? DscImagenAvatar { get; set; }
        public string DscHorarioAtencion { get; set; }
        public string DscCelular { get; set; }
        public string DscCelularOpcional { get; set; }
        public string DscNegocio { get; set; }
        public string DscActivo { get; set; }
        public string DscUsuarioCreacion { get; set; }
        public DateTime? DscFechaCreacion { get; set; }
        public string DscUsuarioModificacion { get; set; }
        public DateTime? DscFechaModificacion { get; set; }
        public string DscNombreComercialCorto { get; set; }

        public List<TipoPagoDto> TipoPago { get; set; }
        public List<ProductoDestacadoDto> ProductosDestacados { get; set; }
        public List<TiempoEntregaDto> TiempoEntrega { get; set; }
        public List<CondicionesDeliveryDto> CondicionesDelivery { get; set; }
        public OpinionDto Opinion { get; set; }
        public List<TiendaHorarioAtencionDto> TiendaHorarioAtencion { get; set; }

    }
}
