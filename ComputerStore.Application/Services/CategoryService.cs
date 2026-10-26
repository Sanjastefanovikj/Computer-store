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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return category == null ? null : _mapper.Map<CategoryDto>(category);
        }

        public async Task CreateAsync(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _categoryRepository.AddAsync(category);
        }

        public async Task UpdateAsync(int id, UpdateCategoryDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                // Handle not found, throw exception or return
                return;
            }
            _mapper.Map(dto, category);
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }
    }
}
