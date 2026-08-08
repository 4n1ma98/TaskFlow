using Models.Requests;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IClientService
    {
        Task<GenericResult> GetAllClientsAsync();
        Task<GenericResult> GetClientByIdAsync(int id);
        Task<GenericResult> GetClientByIdentificationAsync(string identification);
        Task<GenericResult> CreateClientAsync(CreateClientRequest request);
        Task<GenericResult> UpdateClientAsync(UpdateClientRequest request);
        Task<GenericResult> DeleteClientAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
