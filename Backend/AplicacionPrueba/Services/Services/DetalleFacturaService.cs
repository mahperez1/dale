using Entidades.Dominio;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UoW.Interface;

namespace Services.Services
{
    public class DetalleFacturaService : IDetalleFacturaService
    {
        private IUoW _unitOfWork;

        public DetalleFacturaService(IUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ActualizarAsync(DetalleFactura model)
        {
            Boolean respuesta = false;
            try
            {
                if (model != null)
                {
                    Guid newGuid;
                    bool isValid = Guid.TryParse(model.IdDetalleFactura, out newGuid);
                    if (!isValid)
                    {
                        string MsgExcepcion = "El identificador del registro no puede ser nulo o vacío";
                        throw new Exception(MsgExcepcion);
                    }
                    using (var contexto = _unitOfWork.Crear())
                    {
                        List<Producto> Lstproducto = await contexto.Repositorios.ProductoRepositorio.ObtenerTodoAsync();
                        if (Lstproducto.Count > 0)
                        {
                            Producto objProducto = Lstproducto.Where(x => x.IdProducto == model.IdProducto).FirstOrDefault();
                            if (objProducto != null)
                            {
                                string MsgExcepcion = string.Format("No es posible actualizar el registro, El producto que desea asociar no existe");
                                throw new Exception(MsgExcepcion);
                            }
                        }
                        respuesta = await contexto.Repositorios.DetalleFacturaRepositorio.ActualizarAsync(model);
                        if (respuesta)
                        {
                            contexto.SaveChange();
                        }
                    }
                }
                return respuesta;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<bool> CrearAsync(DetalleFactura model)
        {
            Boolean respuesta = false;
            try
            {
                if (model != null)
                {
                    using (var contexto = _unitOfWork.Crear())
                    {
                        List<Producto> LstProducto = await contexto.Repositorios.ProductoRepositorio.ObtenerTodoAsync();
                        if (LstProducto.Count > 0)
                        {
                            Producto objProducto = LstProducto.Where(x => x.IdProducto == model.IdProducto).FirstOrDefault();
                            if (objProducto == null)
                            {
                                string MsgExcepcion = string.Format("No es posible crear el registro, El producto asociar no existe");
                                throw new Exception(MsgExcepcion);
                            }
                        }
                        string id = await contexto.Repositorios.DetalleFacturaRepositorio.CrearAsync(model);
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

        public async Task<IList<DetalleFactura>> ObtenerTodoAsync()
        {
            List<DetalleFactura> lstDetalleFactura = new List<DetalleFactura>();
            try
            {
                using (var contexto = _unitOfWork.Crear())
                {
                    lstDetalleFactura = await contexto.Repositorios.DetalleFacturaRepositorio.ObtenerTodoAsync();
                }
                return lstDetalleFactura.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<DetalleFactura>> ObtenerxIdFacturaAsync(string IdFactura)
        {
            List<DetalleFactura> LstDetalle = new List<DetalleFactura>();
            try
            {
                using (var contexto = _unitOfWork.Crear())
                {
                    LstDetalle = await contexto.Repositorios.DetalleFacturaRepositorio.ObtenerTodoAsync();
                }
                return LstDetalle.Where(x => x.IdFactura == IdFactura).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}