using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositorio.Interfaces.Acciones
{
    public interface IConsultarTodoRepositorio<T> where T : class
    {
        Task<List<T>> ObtenerTodoAsync();

        Task<string> ObtenerTodoJsonAsync();
    }
}