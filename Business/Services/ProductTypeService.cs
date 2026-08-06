using Business.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public async Task<GenericResult> GetAllProductTypesAsync()
        {
            var productTypes = await _productTypeRepository.GetAllAsync();
            return GenericResult.SuccessResult(data: productTypes);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _productTypeRepository.ExistsAsync(id);
        }
    }
}
