using Models.Requests;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IProductService
    {
        Task<GenericResult> GetProductsByIdentificationAsync(int identificationNumber);
        Task<GenericResult> CreateProductAsync(CreateProductRequest request);
    }
}
