using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.SqlServer
{
    public abstract class Repositorio
    {
        protected SqlConnection _contexto;
        protected SqlTransaction _transacion;

        public async Task<string> EjecutarComandoBDAsync(string nombrePA, Dictionary<string, object> lstParametrosEntrada, SqlParameter parametroSalida)
        {
            string valorParametroSalida = string.Empty;
            try
            {
                SqlCommand comando = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = nombrePA, Connection = _contexto, Transaction = _transacion };
                if (lstParametrosEntrada.Count > 0)
                {
                    foreach (var item in lstParametrosEntrada)
                    {
                        comando.Parameters.Add(new SqlParameter() { ParameterName = item.Key, Value = item.Value, IsNullable = true });
                    }
                }
                parametroSalida.Direction = ParameterDirection.Output; parametroSalida.IsNullable = true;
                comando.Parameters.Add(parametroSalida);
                try
                {
                    var reader = await comando.ExecuteNonQueryAsync();
                    valorParametroSalida = Convert.ToString(comando.Parameters[parametroSalida.ParameterName].Value);
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            { throw ex; }
            return valorParametroSalida;
        }

        public async Task<DataTable> EjecutarComandoBDDTAsync(string nombrePA, Dictionary<string, object> lstParametrosEntrada)
        {
            var dt = new DataTable();
            try
            {
                SqlCommand comando = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = nombrePA, Connection = _contexto, Transaction = _transacion };

                if (lstParametrosEntrada.Count > 0)
                {
                    foreach (var item in lstParametrosEntrada)
                    {
                        comando.Parameters.Add(new SqlParameter() { ParameterName = item.Key, Value = item.Value, IsNullable = true });
                    }
                }
                var reader = await comando.ExecuteReaderAsync();
                dt.Load(reader);
                return dt;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> EjecutarComandoBDJSONAsync(string nombrePA, Dictionary<string, object> lstParametrosEntrada)
        {
            var jsonResult = new StringBuilder();
            try
            {
                SqlCommand comando = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = nombrePA, Connection = _contexto, Transaction = _transacion };

                if (lstParametrosEntrada.Count > 0)
                {
                    foreach (var item in lstParametrosEntrada)
                    {
                        comando.Parameters.Add(new SqlParameter() { ParameterName = item.Key, Value = item.Value, IsNullable = true });
                    }
                }
                var reader = await comando.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        jsonResult.Append(reader.GetValue(0).ToString());
                    }
                }

                return jsonResult.ToString();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}