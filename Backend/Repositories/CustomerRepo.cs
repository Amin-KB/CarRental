using System.Diagnostics;
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
                    UpdateCustomerDetails(entity, customer);

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

        /// <summary>
        /// Updates the details of a customer entity with the provided customer details.
        /// </summary>
        /// <param name="entity">The customer entity to be updated.</param>
        /// <param name="customer">The customer details containing the updated information.</param>
        /// <remarks>
        /// This method updates the various properties of the customer entity such as first name, last name,
        /// email, phone number, address, city, postal code, region, and country based on the provided customer details.
        /// </remarks>
        private void UpdateCustomerDetails(Customer entity, Customer customer)
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
        }
        public override async Task<bool> DeleteEntityAsync(int id)
        {
            try
            {
                var customer = await DbSet.FirstOrDefaultAsync(x => x.CustomerId == id);
                if (customer != null)
                {
                    DbSet.Remove(customer);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

    }
}