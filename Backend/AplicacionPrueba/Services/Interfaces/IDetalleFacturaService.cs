using Entidades.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDetalleFacturaService
    {
        #region "Obtener"

        Task<IList<DetalleFactura> > ObtenerxIdFacturaAsync(string idDetalle);

        Task<IList<DetalleFactura>> ObtenerTodoAsync();

        #endregion "Obtener"

        #region "Crear"

        Task<bool> CrearAsync(DetalleFactura model);

        #endregion "Crear"

        #region "Actualizar"

        Task<bool> ActualizarAsync(DetalleFactura model);

        #endregion "Actualizar"
    }
}