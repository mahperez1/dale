using System.Threading.Tasks;

namespace Repositorio.Interfaces.Acciones
{
    public interface IActualizarRepositorio<T> where T : class
    {
        Task<bool> ActualizarAsync(T t);
    }
}