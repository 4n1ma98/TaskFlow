using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Responses.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly FinancialProductsDbContext _context;

        public ProductRepository(FinancialProductsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientProductResponse>> GetProductsByClientIdAsync(int clientId)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(p => p.Client.Id == clientId)
                .Select(p => new ClientProductResponse
                {
                    DocumentType = p.Client.DocumentType,
                    IdentificationNumber = p.Client.IdentificationNumber,
                    FullName = $"{p.Client.FirstName} {p.Client.LastName}",
                    ProductName = p.Name,
                    ProductTypeName = p.ProductType.Name,
                    IsActive = p.IsActive
                })
                .ToListAsync();
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
