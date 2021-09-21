using System.Data.SqlClient;
using UoW.Interface;

namespace UoW.SqlServer
{
    public class UoWSqlServerAdaptador : IUoWAdaptador
    {
        private SqlConnection _contexto { get; set; }
        private SqlTransaction _transaccion { get; set; }
        public IUoWRepositorio Repositorios { get; set; }

        public UoWSqlServerAdaptador(string connectionString)
        {
            _contexto = new SqlConnection(connectionString);
            _contexto.Open();
            _transaccion = _contexto.BeginTransaction();
            Repositorios = new UoWSqlServerRepositorio(_contexto, _transaccion);
        }

        public void Dispose()
        {
            if (_transaccion != null)
            {
                _transaccion.Dispose();
            }
            if (_contexto != null)
            {
                _contexto.Close();
                _contexto.Dispose();
            }
            Repositorios = null;
        }

        public void SaveChange()
        {
            _transaccion.Commit();
        }
    }
}