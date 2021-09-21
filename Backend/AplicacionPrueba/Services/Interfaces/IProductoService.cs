using Entidades.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductoService
    {
        #region "Obtener"

        Task<Producto> ObtenerxIdAsync(string IdProducto);

        Task<IList<Producto>> ObtenerTodoAsync();

        #endregion "Obtener"

        #region "Crear"

        Task<bool> CrearAsync(Producto model);

        #endregion "Crear"

        #region "Actualizar"

        Task<bool> ActualizarAsync(Producto model);

        #endregion "Actualizar"
    }
}