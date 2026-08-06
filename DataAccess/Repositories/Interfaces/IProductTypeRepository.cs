using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IProductTypeRepository
    {
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<ProductType>> GetAllAsync();
    }
}
