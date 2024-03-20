using Backend.Models;

namespace Backend.Contracts
{
    /// <summary>
    /// Interface for a customer repository that extends the base repository interface.
    /// </summary>
    /// <typeparam name="Customer">The type of entity for the customer repository.</typeparam>
    public interface ICustomerRepo:IRepository<Customer>
    {
        
    }
}
