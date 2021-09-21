using Entidades.Dominio;
using Repositorio.Interfaces.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Repositorio.SqlServer.Dominio
{
    public class FacturaRepositorio : Repositorio, IFacturaRepositorio
    {
        #region "Constructor"

        public FacturaRepositorio(SqlConnection contexto, SqlTransaction transacion)
        {
            this._contexto = contexto;
            this._transacion = transacion;
        }

        #endregion "Constructor"

        public async Task<bool> ActualizarAsync(Factura t)
        {
            Boolean respuesta;
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>
                {
                    { "@IdCliente", t.IdCliente},
                    { "@ValorTotal", t.ValorTotal},
                    { "@IdFactura", t.IdFactura},
                };
                int FilasAfectadas = Convert.ToInt32(await EjecutarComandoBDAsync("PA_Factura_Actualizar", lstParametros, new SqlParameter() { ParameterName = "@Resultado", Value = 0 }));
                respuesta = FilasAfectadas > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public async Task<string> CrearAsync(Factura t)
        {
            string respuesta;
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lstParametros.Add("@ValorTotal", t.ValorTotal);
                lstParametros.Add("@IdCliente", t.IdCliente);
                Guid IdFactura = Guid.NewGuid();
                IdFactura = Guid.Parse(await EjecutarComandoBDAsync("PA_Factura_insertar", lstParametros, new SqlParameter() { ParameterName = "@IdFactura", Value = IdFactura }));
                respuesta = (string.IsNullOrEmpty(IdFactura.ToString())) == true ? string.Empty : IdFactura.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public async Task<List<Factura>> ObtenerTodoAsync()
        {
            List<Factura> LstFactura = new List<Factura>();
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                //lstParametros.Add("@TipoConsulta", 3);
                LstFactura = MapInstance.MapearInstanciaObjeto<Factura>(await EjecutarComandoBDDTAsync("PA_Factura_consultar", lstParametros));
                return LstFactura;
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

        public Task<Factura> ObtenerxIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}