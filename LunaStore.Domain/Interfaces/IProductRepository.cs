using LunaStore.Domain.Entities;

namespace LunaStore.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<ProductEntity>
    {
        Task<ProductEntity> GetProductCategoryAsync(int? id);
    }
}
