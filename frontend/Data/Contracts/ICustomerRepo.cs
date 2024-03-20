using frontend.Models;

namespace frontend.Data.Contracts
{
    public interface ICustomerRepo
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<HttpResponseMessage> CreateCustomerAsync(Customer customer);
        Task<HttpResponseMessage> UpdateCustomerAsync(Customer customer);
    }
}
