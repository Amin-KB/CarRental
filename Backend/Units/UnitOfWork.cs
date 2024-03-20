using Backend.Contracts;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Units
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepo CustomerRepo { get ; private set; }
        public ICarRepo CarRepo { get ; private set; }
        public IRentRepo RentRepo { get ; private set; }
        private readonly CarRentalContext _dbContext;

        public UnitOfWork(CarRentalContext dbContext)
        {
            _dbContext = dbContext;
            CustomerRepo = new CustomerRepo(dbContext);
            CarRepo = new CarRepo(dbContext);
            RentRepo = new RentRepo(dbContext);
        }
        public async Task CompleteAsync()
        {
          await _dbContext.SaveChangesAsync();
        }
    }
}
