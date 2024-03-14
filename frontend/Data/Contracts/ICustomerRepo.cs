using frontend.Models;

namespace frontend.Data.Contracts
{
    public interface ICustomerRepo
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
    }
}
