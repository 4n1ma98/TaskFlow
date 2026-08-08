using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api_TaskFlow.Controllers
{
    /// <summary>
    /// Controller responsible for managing financial product types.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypesController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        /// <summary>
        /// Retrieves the catalog of available financial product types.
        /// </summary>
        /// <returns>
        /// A list of available financial product types.
        /// </returns>
        /// <response code="200">
        /// The product types were retrieved successfully.
        /// </response>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productTypeService.GetAllProductTypesAsync();
            return Ok(result);
        }
    }
}
