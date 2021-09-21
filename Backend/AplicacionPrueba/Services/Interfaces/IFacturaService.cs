using Entidades.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IFacturaService
    {
        #region "Obtener"

        Task<Factura> ObtenerxIdAsync(string IdFactura);

        Task<IList<Factura>> ObtenerTodoAsync();

        #endregion "Obtener"

        #region "Crear"

        Task<string> CrearAsync(Factura model);

        #endregion "Crear"

        #region "Actualizar"

        Task<bool> ActualizarAsync(Factura model);

        #endregion "Actualizar"
    }
}