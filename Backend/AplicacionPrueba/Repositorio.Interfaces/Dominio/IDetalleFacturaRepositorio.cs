using Entidades.Dominio;
using Repositorio.Interfaces.Acciones;

namespace Repositorio.Interfaces.Dominio
{
    public interface IDetalleFacturaRepositorio : ICrearRepositorio<DetalleFactura, string>, IActualizarRepositorio<DetalleFactura>, IConsultarTodoRepositorio<DetalleFactura>, IConsultarxIdRepositorio<DetalleFactura, string>

    {
    }
}