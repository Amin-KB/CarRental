using Backend.Contracts;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected CarRentalContext _dbContext;
        internal DbSet<T> DbSet { get; set; }

        public Repository(CarRentalContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<T>();
        }
        public virtual Task<bool> CreateEntityAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> DeleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<List<T>> GetEntitiesAsync()
        {
           return await DbSet.ToListAsync();
        }

        public virtual Task<T> GetEntityByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateEntityAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
