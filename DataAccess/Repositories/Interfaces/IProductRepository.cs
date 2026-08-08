using Models.Entities;
using Models.Responses.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ClientProductResponse>> GetProductsByClientIdAsync(int clientId);
        Task<Product> CreateAsync(Product product);
    }
}
