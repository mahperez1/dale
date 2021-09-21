using Entidades.Dominio;
using Repositorio.Interfaces.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Repositorio.SqlServer.Dominio
{
    public class ProductoRepositorio : Repositorio, IProductoRepositorio
    {
        #region "Constructor"

        public ProductoRepositorio(SqlConnection contexto, SqlTransaction transacion)
        {
            this._contexto = contexto;
            this._transacion = transacion;
        }

        #endregion "Constructor"

        public async Task<bool> ActualizarAsync(Producto t)
        {
            Boolean respuesta;
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>
                {
                    { "@IdProducto", Guid.Parse(t.IdProducto)},
                    { "@Nombre", t.Nombre},
                    { "@IndicaEliminado", t.IndicaEliminado},
                    { "@VlrProducto", t.VlrProducto},
                };
                int FilasAfectadas = Convert.ToInt32(await EjecutarComandoBDAsync("PA_Producto_Actualizar", lstParametros, new SqlParameter() { ParameterName = "@Resultado", Value = 0 }));
                respuesta = FilasAfectadas > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public async Task<string> CrearAsync(Producto t)
        {
            string respuesta;
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lstParametros.Add("@Nombre", t.Nombre);
                lstParametros.Add("@VlrProducto", t.VlrProducto);
                Guid IdProducto = Guid.NewGuid();
                IdProducto = Guid.Parse(await EjecutarComandoBDAsync("PA_Producto_insertar", lstParametros, new SqlParameter() { ParameterName = "@IdProducto", Value = IdProducto }));
                respuesta = (string.IsNullOrEmpty(IdProducto.ToString())) == true ? string.Empty : IdProducto.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public async Task<List<Producto>> ObtenerTodoAsync()
        {
            List<Producto> LstProducto = new List<Producto>();
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                //lstParametros.Add("@TipoConsulta", 3);
                LstProducto = MapInstance.MapearInstanciaObjeto<Producto>(await EjecutarComandoBDDTAsync("PA_Producto_consultar", lstParametros));
                return LstProducto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<string> ObtenerTodoJsonAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Producto> ObtenerxIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}