using LunaStore.Application.DTOs;

namespace LunaStore.Application.Interfaces
{
    public interface IProductService : IBaseService<ProductDTO>
    {
        Task<ProductDTO> GetProductCategory(int? id);
    }
}
