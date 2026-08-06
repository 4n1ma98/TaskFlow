using Business.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using Models.Common;
using Models.Entities;
using Models.Requests;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<GenericResult> GetAllClientsAsync()
        {
            var clients = await _clientRepository.GetAllAsync();
            return GenericResult.SuccessResult(data: clients);
        }

        public async Task<GenericResult> GetClientByIdAsync(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return GenericResult.ErrorResult(ResultCode.NotFound, $"No se encontró el cliente con ID {id}.");
            }

            return GenericResult.SuccessResult(data: client);
        }

        public async Task<GenericResult> CreateClientAsync(CreateClientRequest request)
        {
            var existingClient = await _clientRepository.GetByIdentificationAsync(request.IdentificationNumber);
            if (existingClient != null)
            {
                return GenericResult.ErrorResult(ResultCode.BadRequest, "Ya existe un cliente registrado con ese número de identificación.");
            }

            var newClient = new Client
            {
                DocumentType = request.DocumentType,
                IdentificationNumber = request.IdentificationNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email
            };

            var createdClient = await _clientRepository.CreateAsync(newClient);
            return GenericResult.SuccessResult(data: createdClient, code: ResultCode.Created);
        }

        public async Task<GenericResult> UpdateClientAsync(UpdateClientRequest request)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);
            if (client == null)
            {
                return GenericResult.ErrorResult(ResultCode.NotFound, $"No se encontró el cliente con ID {request.Id}.");
            }

            client.DocumentType = request.DocumentType;
            client.IdentificationNumber = request.IdentificationNumber;
            client.FirstName = request.FirstName;
            client.LastName = request.LastName;
            client.Address = request.Address;
            client.PhoneNumber = request.PhoneNumber;
            client.Email = request.Email;

            var updatedClient = await _clientRepository.UpdateAsync(client);
            return GenericResult.SuccessResult(data: updatedClient, code: ResultCode.Updated);
        }

        public async Task<GenericResult> DeleteClientAsync(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return GenericResult.ErrorResult(ResultCode.NotFound, $"No se encontró el cliente con ID {id}.");
            }

            // Regla de Negocio clave: No se pueden eliminar clientes con productos asociados
            var hasProducts = await _clientRepository.HasProductsAsync(id);
            if (hasProducts)
            {
                return GenericResult.ErrorResult(ResultCode.ClientHasProducts);
            }

            await _clientRepository.DeleteAsync(id);
            return GenericResult.SuccessResult(code: ResultCode.Deleted);
        }
    }
}
