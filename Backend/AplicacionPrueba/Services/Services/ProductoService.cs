using Entidades.Dominio;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UoW.Interface;

namespace Services.Services
{
    public class ProductoService : IProductoService
    {
        private IUoW _unitOfWork;

        public ProductoService(IUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ActualizarAsync(Producto model)
        {
            Boolean respuesta = false;
            try
            {
                if (model != null)
                {
                    Guid newGuid;
                    bool isValid = Guid.TryParse(model.IdProducto, out newGuid);
                    if (!isValid)
                    {
                        string MsgExcepcion = "El identificador del registro no puede ser nulo o vacío";
                        throw new Exception(MsgExcepcion);
                    }
                    using (var contexto = _unitOfWork.Crear())
                    {
                        List<Producto> LstProducto = await contexto.Repositorios.ProductoRepositorio.ObtenerTodoAsync();
                        if (LstProducto.Count > 0)
                        {
                            Producto objproducto = LstProducto.Where(x => x.Nombre.Trim() == model.Nombre.Trim() && x.IdProducto != model.IdProducto).FirstOrDefault();
                            if (objproducto != null)
                            {
                                string MsgExcepcion = string.Format("No es posible actualizar el registro, Ese producto ya esta creado");
                                throw new Exception(MsgExcepcion);
                            }
                        }
                        respuesta = await contexto.Repositorios.ProductoRepositorio.ActualizarAsync(model);
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

        public async Task<bool> CrearAsync(Producto model)
        {
            Boolean respuesta = false;
            try
            {
                if (model != null)
                {
                    using (var contexto = _unitOfWork.Crear())
                    {
                        List<Producto> Lstproductos = await contexto.Repositorios.ProductoRepositorio.ObtenerTodoAsync();
                        if (Lstproductos.Count > 0)
                        {
                            Producto objProducto = Lstproductos.Where(x => x.Nombre.Trim() == model.Nombre.Trim()).FirstOrDefault();
                            if (objProducto != null)
                            {
                                string MsgExcepcion = string.Format("No es posible crear el registro, El Nombre de ese producto ya esta creado");
                                throw new Exception(MsgExcepcion);
                            }
                        }
                        string id = await contexto.Repositorios.ProductoRepositorio.CrearAsync(model);
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

        public async Task<IList<Producto>> ObtenerTodoAsync()
        {
            List<Producto> lstProducto = new List<Producto>();
            try
            {
                using (var contexto = _unitOfWork.Crear())
                {
                    lstProducto = await contexto.Repositorios.ProductoRepositorio.ObtenerTodoAsync();
                }
                return lstProducto.OrderBy(x => x.Nombre).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Producto> ObtenerxIdAsync(string IdProducto)
        {
            List<Producto> lstProducto = new List<Producto>();
            try
            {
                using (var contexto = _unitOfWork.Crear())
                {
                    lstProducto = await contexto.Repositorios.ProductoRepositorio.ObtenerTodoAsync();
                }
                return lstProducto.Where(x => x.IdProducto == IdProducto).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}