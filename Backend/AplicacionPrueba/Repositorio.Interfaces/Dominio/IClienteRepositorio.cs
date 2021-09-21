using Entidades.Dominio;
using Repositorio.Interfaces.Acciones;

namespace Repositorio.Interfaces.Dominio
{
    public interface IClienteRepositorio : ICrearRepositorio<Cliente, string>, IActualizarRepositorio<Cliente>, IConsultarTodoRepositorio<Cliente>, IConsultarxIdRepositorio<Cliente, string>
    {
    }
}