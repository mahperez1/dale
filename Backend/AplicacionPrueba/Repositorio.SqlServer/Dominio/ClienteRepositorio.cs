using Entidades.Dominio;
using Repositorio.Interfaces.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Repositorio.SqlServer.Dominio
{
    public class ClienteRepositorio : Repositorio, IClienteRepositorio
    {
        #region "Constructor"

        public ClienteRepositorio(SqlConnection contexto, SqlTransaction transacion)
        {
            this._contexto = contexto;
            this._transacion = transacion;
        }

        #endregion "Constructor"

        public async Task<bool> ActualizarAsync(Cliente t)
        {
            Boolean respuesta;
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>
                {
                    { "@Cedula", t.Cedula },
                    { "@IndicaEliminado", t.IndicaEliminado},
                    { "@Nombre", t.Nombre},
                    { "@NumeroTelefono", t.NumeroTelefono},
                    { "@IdCliente", Guid.Parse(t.IdCliente)},
                };
                int FilasAfectadas = Convert.ToInt32(await EjecutarComandoBDAsync("PA_Cliente_Actualizar", lstParametros, new SqlParameter() { ParameterName = "@Resultado", Value = 0 }));
                respuesta = FilasAfectadas > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public async Task<string> CrearAsync(Cliente t)
        {
            string respuesta;
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lstParametros.Add("@Cedula", t.Cedula);
                lstParametros.Add("@Nombre", t.Nombre);
                lstParametros.Add("@NumeroTelefono", t.NumeroTelefono);
                Guid Idcliente = Guid.NewGuid();
                Idcliente = Guid.Parse(await EjecutarComandoBDAsync("PA_Cliente_insertar", lstParametros, new SqlParameter() { ParameterName = "@Idcliente", Value = Idcliente }));
                respuesta = (string.IsNullOrEmpty(Idcliente.ToString())) == true ? string.Empty : Idcliente.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public async Task<List<Cliente>> ObtenerTodoAsync()
        {
            List<Cliente> LstCliente = new List<Cliente>();
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                //lstParametros.Add("@TipoConsulta", 3);
                LstCliente = MapInstance.MapearInstanciaObjeto<Cliente>(await EjecutarComandoBDDTAsync("PA_Cliente_consultar", lstParametros));
                return LstCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> ObtenerTodoJsonAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> ObtenerxIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}