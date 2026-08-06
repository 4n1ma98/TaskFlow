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
    public class ClientRepository : IClientRepository
    {
        private readonly FinancialProductsDbContext _context;

        public ClientRepository(FinancialProductsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.AsNoTracking().ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client?> GetByIdentificationAsync(string identificationNumber)
        {
            return await _context.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.IdentificationNumber == identificationNumber);
        }

        public async Task<Client> CreateAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return false;

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HasProductsAsync(int clientId)
        {
            return await _context.Products.AnyAsync(p => p.ClientId == clientId);
        }
    }
}
