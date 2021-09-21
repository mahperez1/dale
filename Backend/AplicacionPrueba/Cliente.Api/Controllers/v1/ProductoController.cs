using AutoMapper;
using Cliente.Api.ViewModels.Producto;
using Entidades.Dominio;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliente.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _ProductoService;
        private readonly IMapper _mapper;

        public ProductoController(IProductoService productoService, IMapper mapper)
        {
            _ProductoService = productoService;
            _mapper = mapper;
        }

        #region Consulta

        [HttpGet("[action]")]
        public async Task<IList<Producto>> Producto()
       {
            IList<Producto> lstProducto = new List<Producto>();
            lstProducto = await _ProductoService.ObtenerTodoAsync();
            return lstProducto;
        }

        [HttpGet("[action]")]
        public async Task<Producto> Productoxcodigo(int codigo)
        {
            IList<Producto> lstProducto = new List<Producto>();
            lstProducto = await _ProductoService.ObtenerTodoAsync();
            return lstProducto.Where(x=> x.CodProducto == codigo).FirstOrDefault();
        }

        #endregion Consulta

        #region Crear

        [HttpPost("[action]")]
        public async Task<IActionResult> Producto(CrearProducto model)
        {
            Producto ObjProducto = new Producto();
            ObjProducto = _mapper.Map<Producto>(model);
            bool respuesta = await _ProductoService.CrearAsync(ObjProducto);
            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion Crear

        #region Actualizar

        [HttpPut("[action]")]
        public async Task<IActionResult> ProductoUp(ActualizarProducto model)
        {
            Producto ObjProducto = new Producto();
            ObjProducto = _mapper.Map<Producto>(model);
            bool respuesta = await _ProductoService.ActualizarAsync(ObjProducto);
            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion Actualizar
    }
}