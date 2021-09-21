using Entidades.Dominio;
using Repositorio.Interfaces.Acciones;

namespace Repositorio.Interfaces.Dominio
{
    public interface IFacturaRepositorio : ICrearRepositorio<Factura, string>, IActualizarRepositorio<Factura>, IConsultarTodoRepositorio<Factura>, IConsultarxIdRepositorio<Factura, string>
    {
    }
}