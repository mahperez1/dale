using Repositorio.Interfaces.Dominio;

namespace UoW.Interface
{
    public interface IUoWRepositorio
    {
        IClienteRepositorio ClienteRepositorio { get; }
        IDetalleFacturaRepositorio DetalleFacturaRepositorio { get; }
        IProductoRepositorio ProductoRepositorio { get; }
        IFacturaRepositorio FacturaRepositorio { get; }
    }
}