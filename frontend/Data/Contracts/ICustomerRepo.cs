using frontend.Models;

namespace frontend.Data.Contracts
{
    public interface ICustomerRepo
    {
        /// <summary>
        /// Retrieves all the customers.
        /// </summary>
        /// <returns>
        /// Task that represents the asynchronous operation.
        /// The task result contains a collection of customers.
        /// </returns>
        Task<IEnumerable<Customer>> GetAllCustomers();

        /// <summary>
        /// Retrieves a customer from the database based on their ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>A Task object representing the asynchronous operation. The task result is the Customer object found in the database.</returns>
        Task<Customer> GetCustomerByIdAsync(int id);

        /// <summary>
        /// Creates a new customer asynchronously.
        /// </summary>
        /// <param name="customer">The customer data.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the HTTP response message.</returns>
        Task<HttpResponseMessage> CreateCustomerAsync(Customer customer);

        /// <summary>
        /// Updates the information of a customer asynchronously.
        /// </summary>
        /// <param name="customer">The updated customer object.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the HTTP response message.</returns>
        Task<HttpResponseMessage> UpdateCustomerAsync(Customer customer);
    }
}
