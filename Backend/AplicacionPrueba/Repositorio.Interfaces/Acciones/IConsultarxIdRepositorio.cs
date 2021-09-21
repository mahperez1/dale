using System.Threading.Tasks;

namespace Repositorio.Interfaces.Acciones
{
    public interface IConsultarxIdRepositorio<T, Y> where T : class
    {
        Task<T> ObtenerxIdAsync(Y id);
    }
}