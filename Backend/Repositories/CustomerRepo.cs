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

        /// <summary>
        /// Retrieves the entities from the database asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result contains a list of Customer entities.</returns>
        public override async Task<List<Customer>> GetEntitiesAsync()
        {
            return await DbSet.ToListAsync();
        }

        /// <summary>
        /// Retrieves a Customer entity from the database based on the provided id. </summary> <param name="id">The id of the Customer entity to retrieve.</param> <returns>
        /// A task representing the asynchronous operation. The task result contains the retrieved Customer entity,
        /// or null if no entity is found with the provided id. </returns>
        /// /
        public override async Task<Customer> GetEntityByIdAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.CustomerId == id);
        }

        /// <summary>
        /// Asynchronously creates a new entity of type "Customer" in the database.
        /// </summary>
        /// <param name="customer">The customer object to be created.</param>
        /// <returns>Returns a task representing the asynchronous operation. The task result will be "true" if the entity is created successfully, otherwise "false".</returns>
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

        /// <summary>
        /// Updates the customer entity in the database based on the provided Customer object.
        /// </summary>
        /// <param name="customer">The Customer object containing the updated information.</param>
        /// <returns>
        /// Returns a Task that represents the asynchronous operation. The task result is a Boolean value indicating
        /// whether the update was successful or not. True if the entity was updated, otherwise False.
        /// </returns>
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