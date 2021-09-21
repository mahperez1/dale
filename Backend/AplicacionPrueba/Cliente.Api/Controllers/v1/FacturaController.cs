using AutoMapper;
using Cliente.Api.ViewModels.Factura;
using Entidades.Dominio;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cliente.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _FacturaService;
        private readonly IMapper _mapper;

        public FacturaController(IFacturaService facturaService, IMapper mapper)
        {
            _FacturaService = facturaService;
            _mapper = mapper;
        }

        #region Consulta

        [HttpGet("[action]")]
        public async Task<IList<Factura>> Factura()
        {
            IList<Factura> lstfactura = new List<Factura>();
            lstfactura = await _FacturaService.ObtenerTodoAsync();
            return lstfactura;
        }

        #endregion Consulta

        #region Crear

        [HttpPost("[action]")]
        public async Task<string> Factura(CrearFactura model)
        {
            Factura ObjFactura = new Factura();
            ObjFactura = _mapper.Map<Factura>(model);
            string respuesta = await _FacturaService.CrearAsync(ObjFactura);
            return respuesta;
        }

        #endregion Crear

        #region Actualizar

        [HttpPut("[action]")]
        public async Task<IActionResult> FacturaUp(ActualizarFactura model)
        {
            Factura ObjFactura = new Factura();
            ObjFactura = _mapper.Map<Factura>(model);
            bool respuesta = await _FacturaService.ActualizarAsync(ObjFactura);
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