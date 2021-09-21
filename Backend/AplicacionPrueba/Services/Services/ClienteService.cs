using Entidades.Dominio;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UoW.Interface;

namespace Services.Services
{
    public class ClienteService : IClienteService
    {
        private IUoW _unitOfWork;

        public ClienteService(IUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ActualizarAsync(Cliente model)
        {
            Boolean respuesta = false;
            try
            {
                if (model != null)
                {
                    using (var contexto = _unitOfWork.Crear())
                    {
                        List<Cliente> Lstclientes = await contexto.Repositorios.ClienteRepositorio.ObtenerTodoAsync();
                        if (Lstclientes.Count > 0)
                        {
                            Guid newGuid;
                            bool isValid = Guid.TryParse(model.IdCliente, out newGuid);
                            if (!isValid)
                            {
                                string MsgExcepcion = "El identificador del registro no puede ser nulo o vacío";
                                throw new Exception(MsgExcepcion);
                            }
                            Cliente objCliente = Lstclientes.Where(x => x.Cedula == model.Cedula && x.IdCliente != model.IdCliente).FirstOrDefault();
                            if (objCliente != null)
                            {
                                string MsgExcepcion = string.Format("No es posible actualizar el registro, El tipo de identificacion pertenece a otra persona");
                                throw new Exception(MsgExcepcion);
                            }
                        }
                        respuesta = await contexto.Repositorios.ClienteRepositorio.ActualizarAsync(model);
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

        public async Task<bool> CrearAsync(Cliente model)
        {
            Boolean respuesta = false;
            try
            {
                if (model != null)
                {
                    using (var contexto = _unitOfWork.Crear())
                    {
                        List<Cliente> Lstclientes = await contexto.Repositorios.ClienteRepositorio.ObtenerTodoAsync();
                        if (Lstclientes.Count > 0)
                        {
                            Cliente objCliente = Lstclientes.Where(x => x.Cedula == model.Cedula).FirstOrDefault();
                            if (objCliente != null)
                            {
                                string MsgExcepcion = string.Format("No es posible crear el registro, El Numero de identificacion pertence a otra persona ");
                                throw new Exception(MsgExcepcion);
                            }
                        }
                        string id = await contexto.Repositorios.ClienteRepositorio.CrearAsync(model);
                        if (!string.IsNullOrEmpty(id))
                        {
                            contexto.SaveChange();
                            respuesta = true;
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

        public async Task<IList<Cliente>> ObtenerTodoAsync()
        {
            List<Cliente> lstCliente = new List<Cliente>();
            try
            {
                using (var contexto = _unitOfWork.Crear())
                {
                    lstCliente = await contexto.Repositorios.ClienteRepositorio.ObtenerTodoAsync();
                }
                return lstCliente.OrderBy(x => x.Nombre).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> ObtenerxIdAsync(string idCliente)
        {
            List<Cliente> lstCliente = new List<Cliente>();
            try
            {
                using (var contexto = _unitOfWork.Crear())
                {
                    lstCliente = await contexto.Repositorios.ClienteRepositorio.ObtenerTodoAsync();
                }
                return lstCliente.Where(x => x.IdCliente == idCliente).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}