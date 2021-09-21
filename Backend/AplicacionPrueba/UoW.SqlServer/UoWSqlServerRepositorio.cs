using Repositorio.Interfaces.Dominio;
using Repositorio.SqlServer.Dominio;
using System.Data.SqlClient;
using UoW.Interface;

namespace UoW.SqlServer
{
    public class UoWSqlServerRepositorio : IUoWRepositorio
    {
        public IDetalleFacturaRepositorio DetalleFacturaRepositorio { get; }
        public IProductoRepositorio ProductoRepositorio { get; }
        public IClienteRepositorio ClienteRepositorio { get; }
        public IFacturaRepositorio FacturaRepositorio { get; }

        public UoWSqlServerRepositorio(SqlConnection contexto, SqlTransaction transaccion)
        {
            ClienteRepositorio = new ClienteRepositorio(contexto, transaccion);
            ProductoRepositorio = new ProductoRepositorio(contexto, transaccion);
            DetalleFacturaRepositorio = new DetalleFacturaRepositorio(contexto, transaccion);
            FacturaRepositorio = new FacturaRepositorio(contexto, transaccion);
        }
    }
}