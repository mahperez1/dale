using Entidades.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IClienteService
    {
        #region "Obtener"

        Task<Cliente> ObtenerxIdAsync(string idCliente);

        Task<IList<Cliente>> ObtenerTodoAsync();

        #endregion "Obtener"

        #region "Crear"

        Task<bool> CrearAsync(Cliente model);

        #endregion "Crear"

        #region "Actualizar"

        Task<bool> ActualizarAsync(Cliente model);

        #endregion "Actualizar"
    }
}