using Backend.Contracts;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class CustomerRepo : Repository<Customer>, ICustomerRepo
    {
        public CustomerRepo(CarRentalContext dbContext) : base(dbContext)
        {
        }

        public override async Task<List<Customer>> GetEntitiesAsync()
        {
            return await DbSet.ToListAsync();
        }

        public override async Task<Customer> GetEntityByIdAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.CustomerId == id);
        }

        public override async Task<bool> CreateEntityAsync(Customer customer)
        {
            try
            {
                await DbSet.AddAsync(customer);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public override async Task<bool> UpdateEntityAsync(Customer customer)
        {
            try
            {
                var entity = await DbSet.FirstOrDefaultAsync(x => x.CustomerId == customer.CustomerId);
                if (entity != null)
                {
                    entity.FirstName = customer.FirstName;
                    entity.LastName = customer.LastName;
                    entity.Email = customer.Email;
                    entity.Phone = customer.Phone;
                    entity.Address = customer.Address;
                    entity.City = customer.City;
                    entity.Postal = customer.Postal;
                    entity.Region = customer.Region;
                    entity.Country = customer.Country;

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}