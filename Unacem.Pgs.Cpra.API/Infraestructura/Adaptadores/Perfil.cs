using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Unacem.Pgs.Admin.AplicacionCore.Agregados.Tienda;
using Unacem.Pgs.Admin.AplicacionCore.Dto.Tienda;

using Unacem.Pgs.Cpra.AplicacionCore.Dto.Tienda;

namespace Unacem.Pgs.Cpra.API.Infraestructura.Adaptadores
{
    class Perfil : Profile
    {
        protected override void Configure()
        {
            //Mapper.CreateMap<Compra, CompraCreadaDto>();
            //Mapper.CreateMap<Compra, CompraDto>();
            //Mapper.CreateMap<CompraDetalle, CompraDetalleDto>();
            Mapper.CreateMap<TiendaProgresol, TiendaCreadaDto>();

            //Mapper.CreateMap<Material, MaterialDto>();
            //Mapper.CreateMap<Proveedor, ProveedorDto>();
            Mapper.CreateMap<TiendaProgresol, TiendaDto>();
        }
    }
}
