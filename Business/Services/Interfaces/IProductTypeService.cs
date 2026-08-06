using Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IProductTypeService
    {
        Task<GenericResult> GetAllProductTypesAsync();
        Task<bool> ExistsAsync(int id);
    }
}
