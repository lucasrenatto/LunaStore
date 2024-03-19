using LunaStore.Domain.Entities;

namespace LunaStore.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int? id);
        Task<T> CreateAsync(T t);
        Task<T> UpdateAsync(T t);
        Task<T> RemoveAsync(T t);
    }
}
