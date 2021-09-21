using System.Threading.Tasks;

namespace Repositorio.Interfaces.Acciones
{
    public interface IConsultarxNombreRepositorio<T, Y> where T : class
    {
        Task<T> ObtenerxNombreAsync(Y nombre);
    }
}
