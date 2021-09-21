using Entidades.Dominio;
using Repositorio.Interfaces.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Repositorio.SqlServer.Dominio
{
    public class DetalleFacturaRepositorio : Repositorio, IDetalleFacturaRepositorio
    {
        #region "Constructor"

        public DetalleFacturaRepositorio(SqlConnection contexto, SqlTransaction transacion)
        {
            this._contexto = contexto;
            this._transacion = transacion;
        }

        #endregion "Constructor"

        public async Task<bool> ActualizarAsync(DetalleFactura t)
        {
            Boolean respuesta;
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>
                {
                    { "@IdDetalleFactura", t.IdDetalleFactura},
                    { "@IdProducto", t.IdProducto},
                    { "@ValorParcial", t.ValorParcial},
                    { "@Cantidad", t.Cantidad}
                };
                int FilasAfectadas = Convert.ToInt32(await EjecutarComandoBDAsync("PA_DetalleFactura_Actualizar", lstParametros, new SqlParameter() { ParameterName = "@Resultado", Value = 0 }));
                respuesta = FilasAfectadas > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public async Task<string> CrearAsync(DetalleFactura t)
        {
            string respuesta;
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                lstParametros.Add("@Cantidad", t.Cantidad);
                lstParametros.Add("@IdProducto", t.IdProducto);
                lstParametros.Add("@ValorParcial", t.ValorParcial);
                lstParametros.Add("@IdFactura", t.IdFactura);
                Guid IdDetalleFactura = Guid.NewGuid();
                IdDetalleFactura = Guid.Parse(await EjecutarComandoBDAsync("PA_DetalleFactura_insertar", lstParametros, new SqlParameter() { ParameterName = "@IdDetalleFactura", Value = IdDetalleFactura }));
                respuesta = (string.IsNullOrEmpty(IdDetalleFactura.ToString())) == true ? string.Empty : IdDetalleFactura.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }

        public async Task<List<DetalleFactura>> ObtenerTodoAsync()
        {
            List<DetalleFactura> LstDetalleFactura = new List<DetalleFactura>();
            try
            {
                Dictionary<string, object> lstParametros = new Dictionary<string, object>();
                //lstParametros.Add("@TipoConsulta", 3);
                LstDetalleFactura = MapInstance.MapearInstanciaObjeto<DetalleFactura>(await EjecutarComandoBDDTAsync("PA_DetalleFactura_consultar", lstParametros));
                return LstDetalleFactura;
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

        public Task<DetalleFactura> ObtenerxIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}