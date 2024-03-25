namespace LunaStore.Application.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int? id);
        Task AddAsync(T dto);
        Task UpdateAsync(T dto);
        Task DeleteAsync(int? id);

    }
}
