using AutoMapper;
using Cliente.Api.ViewModels.DetalleFactura;
using Entidades.Dominio;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cliente.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DetalleFacturaController : ControllerBase
    {
        private readonly IDetalleFacturaService _DetalleFacturaService;
        private readonly IMapper _mapper;

        public DetalleFacturaController(IDetalleFacturaService detalleFacturaService, IMapper mapper)
        {
            _DetalleFacturaService = detalleFacturaService;
            _mapper = mapper;
        }

        #region Consulta

        [HttpGet("[action]")]
        public async Task<IList<DetalleFactura>> DetalleFactura()
        {
            IList<DetalleFactura> lstDetalle = new List<DetalleFactura>();
            lstDetalle = await _DetalleFacturaService.ObtenerTodoAsync();
            return lstDetalle;
        }

        [HttpGet("[action]")]
        public async Task<IList<DetalleFactura>> DetalleFacturaxId(string id)
        {
            IList<DetalleFactura> LstDetalle = new List<DetalleFactura>();
            LstDetalle = await _DetalleFacturaService.ObtenerxIdFacturaAsync(id);
            return LstDetalle;
        }

        #endregion Consulta

        #region Crear

        [HttpPost("[action]")]
        public async Task<IActionResult> DetalleFactura(CrearDetalleFactura model)
        {
            DetalleFactura objdetalle = new DetalleFactura();
            objdetalle = _mapper.Map<DetalleFactura>(model);
            bool respuesta = await _DetalleFacturaService.CrearAsync(objdetalle);
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
        public async Task<IActionResult> DetalleFacturaUp(DetalleFactura model)
        {
            DetalleFactura objdetalle = new DetalleFactura();
            objdetalle = _mapper.Map<DetalleFactura>(model);
            bool respuesta = await _DetalleFacturaService.ActualizarAsync(objdetalle);
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