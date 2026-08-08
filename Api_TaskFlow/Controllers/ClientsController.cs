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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clientService.GetAllClientsAsync();
            return Ok(result);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _clientService.GetClientByIdAsync(id);
            if (!result.IsSuccessful)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("GetByIdentification/{identification:int}")]
        public async Task<IActionResult> GetByIdentification(int identification)
        {
            var result = await _clientService.GetClientByIdentificationAsync(identification.ToString());
            if (!result.IsSuccessful)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateClientRequest request)
        {
            var result = await _clientService.CreateClientAsync(request);
            if (!result.IsSuccessful)
            {
                return BadRequest(result);
            }
            return StatusCode(201, result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateClientRequest request)
        {
            var result = await _clientService.UpdateClientAsync(request);
            if (!result.IsSuccessful)
            {
                if (result.Id == (int)ResultCode.NotFound) return NotFound(result);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _clientService.DeleteClientAsync(id);
            if (!result.IsSuccessful)
            {
                if (result.Id == (int)ResultCode.NotFound) return NotFound(result);
                return BadRequest(result); // Devuelve HTTP 400 cuando falla la regla de negocio
            }
            return Ok(result);
        }

        [HttpGet("test-error")]
        public IActionResult TestError()
        {
#pragma warning disable S112
            throw new Exception("Prueba de excepción no controlada en el Middleware");
#pragma warning restore S112
        }
    }
}
