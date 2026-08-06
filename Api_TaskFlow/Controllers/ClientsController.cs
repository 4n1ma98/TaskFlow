using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Common;
using Models.Requests;

namespace Api_TaskFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clientService.GetAllClientsAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _clientService.GetClientByIdAsync(id);
            if (!result.IsSuccesfull)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClientRequest request)
        {
            var result = await _clientService.CreateClientAsync(request);
            if (!result.IsSuccesfull)
            {
                return BadRequest(result);
            }
            return StatusCode(201, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateClientRequest request)
        {
            var result = await _clientService.UpdateClientAsync(request);
            if (!result.IsSuccesfull)
            {
                if (result.Id == (int)ResultCode.NotFound) return NotFound(result);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _clientService.DeleteClientAsync(id);
            if (!result.IsSuccesfull)
            {
                if (result.Id == (int)ResultCode.NotFound) return NotFound(result);
                return BadRequest(result); // Devuelve HTTP 400 cuando falla la regla de negocio
            }
            return Ok(result);
        }

        [HttpGet("test-error")]
        public IActionResult TestError()
        {
            throw new Exception("Prueba de excepción no controlada en el Middleware");
        }
    }
}
