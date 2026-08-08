using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Common;
using Models.Requests;

namespace Api_TaskFlow.Controllers
{
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
        /// Consultar productos financieros por identificación del cliente
        /// </summary>
        [HttpGet("ByClientIdentification/{clientIdentification}")]
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
        /// Asociar un nuevo producto a un cliente
        /// </summary>
        [HttpPost]
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
