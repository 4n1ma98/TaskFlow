using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Common;
using Models.Requests;

namespace Api_TaskFlow.Controllers
{
    /// <summary>
    /// Controller responsible for managing clients.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Retrieves all registered clients.
        /// </summary>
        /// <returns>A list containing all registered clients.</returns>
        /// <response code="200">Clients were retrieved successfully.</response>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clientService.GetAllClientsAsync();
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a client by its internal identifier.
        /// </summary>
        /// <param name="id">The internal identifier of the client.</param>
        /// <returns>The requested client.</returns>
        /// <response code="200">The client was found successfully.</response>
        /// <response code="404">The client was not found.</response>
        [HttpGet("GetById/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _clientService.GetClientByIdAsync(id);
            if (!result.IsSuccessful)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a client by their identification number.
        /// </summary>
        /// <param name="identification">
        /// The client's identification number.
        /// </param>
        /// <returns>The requested client.</returns>
        /// <response code="200">The client was found successfully.</response>
        /// <response code="404">The client was not found.</response>
        [HttpGet("GetByIdentification/{identification:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdentification(int identification)
        {
            var result = await _clientService.GetClientByIdentificationAsync(identification.ToString());
            if (!result.IsSuccessful)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Creates a new client.
        /// </summary>
        /// <param name="request">The information required to create the client.</param>
        /// <returns>The result of the client creation operation.</returns>
        /// <response code="201">The client was created successfully.</response>
        /// <response code="400">The request contains invalid data or the client could not be created.</response>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateClientRequest request)
        {
            var result = await _clientService.CreateClientAsync(request);
            if (!result.IsSuccessful)
            {
                return BadRequest(result);
            }
            return StatusCode(201, result);
        }

        /// <summary>
        /// Updates an existing client.
        /// </summary>
        /// <param name="request">The information required to update the client.</param>
        /// <returns>The result of the client update operation.</returns>
        /// <response code="200">The client was updated successfully.</response>
        /// <response code="400">The request contains invalid data or the update could not be completed.</response>
        /// <response code="404">The client was not found.</response>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Deletes a client by its internal identifier.
        /// </summary>
        /// <param name="id">The internal identifier of the client.</param>
        /// <returns>The result of the client deletion operation.</returns>
        /// <response code="200">The client was deleted successfully.</response>
        /// <response code="400">
        /// The client could not be deleted because a business rule was violated.
        /// </response>
        /// <response code="404">The client was not found.</response>
        [HttpDelete("Delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
