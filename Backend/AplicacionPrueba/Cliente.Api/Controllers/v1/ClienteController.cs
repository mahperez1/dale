using AutoMapper;
using Cliente.Api.ViewModels.Cliente;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliente.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _ClienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _ClienteService = clienteService;
            _mapper = mapper;
        }

        #region Consulta

        [HttpGet("[action]")]
        public async Task<IList<Entidades.Dominio.Cliente>> Cliente()
        {
            IList<Entidades.Dominio.Cliente> lstCliente = new List<Entidades.Dominio.Cliente>();
            lstCliente = await _ClienteService.ObtenerTodoAsync();
            return lstCliente;
        }

        [HttpGet("[action]")]
        public async Task<Entidades.Dominio.Cliente> Clientexcedula(string cedula)
        {
            IList<Entidades.Dominio.Cliente> lstCliente = new List<Entidades.Dominio.Cliente>();
            lstCliente = await _ClienteService.ObtenerTodoAsync();
            return lstCliente.Where(x=> x.Cedula.Trim() == cedula.Trim()).FirstOrDefault();
        }

        #endregion Consulta

        #region Crear

        [HttpPost("[action]")]
        public async Task<IActionResult> Cliente(CrearCliente model)
        {
            Entidades.Dominio.Cliente objCliente = new Entidades.Dominio.Cliente();
            objCliente = _mapper.Map<Entidades.Dominio.Cliente>(model);
            bool respuesta = await _ClienteService.CrearAsync(objCliente);
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
        public async Task<IActionResult> ClienteUp(ActualizarCliente model)
        {
            Entidades.Dominio.Cliente objCliente = new Entidades.Dominio.Cliente();
            objCliente = _mapper.Map<Entidades.Dominio.Cliente>(model);
            bool respuesta = await _ClienteService.ActualizarAsync(objCliente);
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