using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using ComputerStore.Application.Dtos;
using ComputerStore.Application.Interfaces;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStore.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductDto>(product);
        }

        public async Task CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                // Handle not found, throw exception or return
                return;
            }
            _mapper.Map(dto, product);
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
