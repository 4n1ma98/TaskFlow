using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Common;
using Models.Requests;

namespace Api_TaskFlow.Controllers
{
    /// <summary>
    /// Controller responsible for managing financial products associated with clients.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Retrieves the financial products associated with a client by their identification number.
        /// </summary>
        /// <param name="clientIdentification">
        /// The identification number of the client.
        /// </param>
        /// <returns>
        /// A list of financial products associated with the specified client.
        /// </returns>
        /// <response code="200">
        /// The client's financial products were retrieved successfully.
        /// </response>
        /// <response code="400">
        /// The request contains invalid data.
        /// </response>
        /// <response code="404">
        /// The client was not found.
        /// </response>
        [HttpGet("ByClientIdentification/{clientIdentification}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByClient(string clientIdentification)
        {
            var result = await _productService.GetProductsByIdentificationAsync(clientIdentification);
            if (!result.IsSuccessful)
            {
                if (result.Id == (int)ResultCode.NotFound) return NotFound(result);
                return BadRequest(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Associates a new financial product with a client.
        /// </summary>
        /// <param name="request">
        /// The information required to create and associate the financial product.
        /// </param>
        /// <returns>
        /// The result of the product association operation.
        /// </returns>
        /// <response code="201">
        /// The financial product was created and associated with the client successfully.
        /// </response>
        /// <response code="400">
        /// The request contains invalid data or the specified product type does not exist.
        /// </response>
        /// <response code="404">
        /// The client or another required resource was not found.
        /// </response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
        {
            var result = await _productService.CreateProductAsync(request);
            if (!result.IsSuccessful)
            {
                if (result.Id == (int)ResultCode.NotFound) return NotFound(result);
                return BadRequest(result);
            }
            return StatusCode(201, result);
        }
    }
}
