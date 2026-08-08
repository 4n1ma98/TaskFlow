using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api_TaskFlow.Controllers
{
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
        /// Obtiene el catálogo de tipos de productos paramétricos (Cuentas, Tarjetas, Préstamos, etc.)
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productTypeService.GetAllProductTypesAsync();
            return Ok(result);
        }
    }
}
