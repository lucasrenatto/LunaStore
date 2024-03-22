using LunaStore.Domain.Entities;
using LunaStore.Domain.Interfaces;
using LunaStore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LunaStore.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductEntity> CreateAsync(ProductEntity product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
           return await _context.Products.ToListAsync();
        }

        public async Task<ProductEntity?> GetByIdAsync(int? id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<ProductEntity> GetProductCategoryAsync(int? id)
        {
            return await _context.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProductEntity> RemoveAsync(ProductEntity product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<ProductEntity> UpdateAsync(ProductEntity product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
