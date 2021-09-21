using Entidades.Dominio;
using Repositorio.Interfaces.Acciones;

namespace Repositorio.Interfaces.Dominio
{
    public interface IProductoRepositorio : ICrearRepositorio<Producto, string>, IActualizarRepositorio<Producto>, IConsultarTodoRepositorio<Producto>, IConsultarxIdRepositorio<Producto, string>
    {
    }
}