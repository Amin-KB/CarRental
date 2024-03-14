using Backend.Contracts;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Units
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepo CustomerRepo { get ; private set; }
        private readonly CarRentalContext _dbContext;

        public UnitOfWork(CarRentalContext dbContext)
        {
            _dbContext = dbContext;
            CustomerRepo = new CustomerRepo(dbContext);
        }
        public async Task CompleteAsync()
        {
          await _dbContext.SaveChangesAsync();
        }
    }
}
