namespace Backend.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetEntitiesAsync();
        Task<T> GetEntityByIdAsync(int id);
        Task<bool> CreateEntityAsync(T entity);
        Task<bool> UpdateEntityAsync(T entity);
        Task<bool> DeleteEntityAsync(int id);
    }
}
