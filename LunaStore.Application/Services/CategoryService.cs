using AutoMapper;
using LunaStore.Application.DTOs;
using LunaStore.Application.Interfaces;
using LunaStore.Domain.Entities;
using LunaStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaStore.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _repo = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository)); ;
            _mapper = mapper;
        }

        public async Task AddAsync(CategoryDTO dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            await _repo.CreateAsync(entity);
        }

        public async Task DeleteAsync(int? id)
        {
            var entity = await _repo.GetByIdAsync(id);
            await _repo.RemoveAsync(entity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var entity = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(entity);
        }

        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(entity);
        }

        public async Task UpdateAsync(CategoryDTO dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            await _repo.UpdateAsync(entity);
        }
    }
}
