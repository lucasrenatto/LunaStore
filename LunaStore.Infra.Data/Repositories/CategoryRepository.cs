using LunaStore.Domain.Entities;
using LunaStore.Domain.Interfaces;
using LunaStore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LunaStore.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryEntity> CreateAsync(CategoryEntity category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<CategoryEntity>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<CategoryEntity?> GetByIdAsync(int? id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<CategoryEntity> RemoveAsync(CategoryEntity category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<CategoryEntity> UpdateAsync(CategoryEntity category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
