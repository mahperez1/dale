using Entidades.Dominio;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UoW.Interface;

namespace Services.Services
{
    public class FacturaService : IFacturaService
    {
        private IUoW _unitOfWork;

        public FacturaService(IUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ActualizarAsync(Factura model)
        {
            Boolean respuesta = false;
            try
            {
                if (model != null)
                {
                    Guid newGuid;
                    bool isValid = Guid.TryParse(model.IdFactura, out newGuid);
                    if (!isValid)
                    {
                        string MsgExcepcion = "El identificador del registro no puede ser nulo o vacío";
                        throw new Exception(MsgExcepcion);
                    }
                    using (var contexto = _unitOfWork.Crear())
                    {
                        List<Factura> Lstfactura = await contexto.Repositorios.FacturaRepositorio.ObtenerTodoAsync();
                        List<Cliente> lstcliente = await contexto.Repositorios.ClienteRepositorio.ObtenerTodoAsync();
                        if (Lstfactura.Count > 0)
                        {
                            Factura objfactura = Lstfactura.Where(x => x.IdFactura == model.IdFactura).FirstOrDefault();
                            if (objfactura == null)
                            {
                                string MsgExcepcion = string.Format("No es posible actualizar el registro, La factura que desea actualizar no existe");
                                throw new Exception(MsgExcepcion);
                            }
                            Cliente objcliente = lstcliente.Where(x => x.IdCliente == model.IdCliente).FirstOrDefault();
                            if (objcliente == null)
                            {
                                string MsgExcepcion = string.Format("No es posible actualizar el registro, El cliente no existe");
                                throw new Exception(MsgExcepcion);
                            }
                        }
                        respuesta = await contexto.Repositorios.FacturaRepositorio.ActualizarAsync(model);
                        if (respuesta)
                        {
                            contexto.SaveChange();
                        }
                    }
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> CrearAsync(Factura model)
        {
            string respuesta = string.Empty;
            try
            {
                if (model != null)
                {
                    using (var contexto = _unitOfWork.Crear())
                    {
                        List<Cliente> lstcliente = await contexto.Repositorios.ClienteRepositorio.ObtenerTodoAsync();
                        if (lstcliente.Count > 0)
                        {
                            Cliente objcliente = lstcliente.Where(x => x.IdCliente == model.IdCliente).FirstOrDefault();
                            if (objcliente == null)
                            {
                                string MsgExcepcion = string.Format("No es posible crear el registro, El cliente no existe");
                                throw new Exception(MsgExcepcion);
                            }
                        }
                        string id = await contexto.Repositorios.FacturaRepositorio.CrearAsync(model);
                        if (!string.IsNullOrEmpty(id))
                        {
                            contexto.SaveChange();
                            respuesta = id;
                        }
                    }
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<Factura>> ObtenerTodoAsync()
        {
            List<Factura> lstFactura = new List<Factura>();
            try
            {
                using (var contexto = _unitOfWork.Crear())
                {
                    lstFactura = await contexto.Repositorios.FacturaRepositorio.ObtenerTodoAsync();
                }
                return lstFactura.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Factura> ObtenerxIdAsync(string IdFactura)
        {
            List<Factura> lstfacturas = new List<Factura>();
            try
            {
                using (var contexto = _unitOfWork.Crear())
                {
                    lstfacturas = await contexto.Repositorios.FacturaRepositorio.ObtenerTodoAsync();
                }
                return lstfacturas.Where(x => x.IdFactura == IdFactura).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}