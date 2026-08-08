using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Business.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using Models.Common;
using Models.Entities;
using Models.Requests;
using Models.Responses;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IClientService _clientService;
        private readonly IProductTypeService _productTypeService;

        public ProductService(
            IProductRepository productRepository,
            IClientService clientService,
            IProductTypeService productTypeService)
        {
            _productRepository = productRepository;
            _clientService = clientService;
            _productTypeService = productTypeService;
        }

        // Consultar los productos financieros por identificación del cliente
        public async Task<GenericResult> GetProductsByIdentificationAsync(string clientIdentificacion)
        {
            var client = await _clientService.GetClientByIdentificationAsync(clientIdentificacion);
            if (!client.IsSuccessful)
            {
                return GenericResult.ErrorResult(ResultCode.NotFound, $"No existe un cliente registrado con la identificación {clientIdentificacion}.");
            }

            var products = await _productRepository.GetProductsByClientIdAsync(((Client)client.Data!).Id);
            return GenericResult.SuccessResult(data: products);
        }

        // Asociar un nuevo producto a un cliente (con validación de ProductType inexistente)
        public async Task<GenericResult> CreateProductAsync(CreateProductRequest request)
        {
            // 1. Validar que el cliente exista
            var client = await _clientService.GetClientByIdAsync(request.ClientId);
            if (!client.IsSuccessful)
            {
                return GenericResult.ErrorResult(ResultCode.NotFound, $"No existe un cliente registrado con ID {request.ClientId}.");
            }

            // 2. Validar que el tipo de producto exista en el catálogo
            var productTypeExists = await _productTypeService.ExistsAsync(request.ProductTypeId);
            if (!productTypeExists)
            {
                return GenericResult.ErrorResult(ResultCode.ProductTypeNotFound, $"El Tipo de Producto con ID {request.ProductTypeId} no existe en el catálogo.");
            }

            // 3. Crear y asociar el nuevo producto
            var newProduct = new Product
            {
                Name = request.Name,
                ProductTypeId = request.ProductTypeId,
                ClientId = request.ClientId,
                IsActive = true
            };

            var createdProduct = await _productRepository.CreateAsync(newProduct);
            return GenericResult.SuccessResult(data: createdProduct, code: ResultCode.Created);
        }
    }
}
