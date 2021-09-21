using System.Threading.Tasks;

namespace Repositorio.Interfaces.Acciones
{
    public interface ICrearRepositorio<T, Y> where T : class
    {
        Task<Y> CrearAsync(T t);
    }
}