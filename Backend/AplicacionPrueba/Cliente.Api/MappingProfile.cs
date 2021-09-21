using AutoMapper;
using Cliente.Api.ViewModels.Cliente;
using Cliente.Api.ViewModels.DetalleFactura;
using Cliente.Api.ViewModels.Factura;
using Cliente.Api.ViewModels.Producto;
using Entidades.Dominio;

namespace Cliente.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region "ViewModels to models"

            #region "Negocio"

            #region "Cliente"

            CreateMap<CrearCliente, Entidades.Dominio.Cliente>();
            CreateMap<ActualizarCliente, Entidades.Dominio.Cliente>();

            #endregion "Cliente"

            #region "DetalleFactura"

            CreateMap<CrearDetalleFactura, DetalleFactura>();
            CreateMap<ActualizarDetalleFactura, DetalleFactura>();

            #endregion "DetalleFactura"

            #region "Factura"

            CreateMap<CrearFactura, Factura>();
            CreateMap<ActualizarFactura, Factura>();

            #endregion "Factura"

            #region "Producto"

            CreateMap<CrearProducto, Producto>();
            CreateMap<ActualizarProducto, Producto>();

            #endregion "Producto"

            #endregion "Negocio"

            #endregion "ViewModels to models"
        }
    }
}