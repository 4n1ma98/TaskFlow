using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly FinancialProductsDbContext _context;
        public ProductTypeRepository(FinancialProductsDbContext context) => _context = context;

        public async Task<bool> ExistsAsync(int id)
            => await _context.ProductTypes.AnyAsync(pt => pt.Id == id);

        public async Task<IEnumerable<ProductType>> GetAllAsync()
            => await _context.ProductTypes.AsNoTracking().ToListAsync();
    }
}
