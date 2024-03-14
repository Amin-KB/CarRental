using frontend.Data.Contracts;
using frontend.Models;
using System.Net.Http.Json;

namespace frontend.Data
{
    public class CustomerRepo: ICustomerRepo
    {
        private HttpClient _httpClient;
        public CustomerRepo()
        {

            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5202/api/") };

        }
         
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            try
            {
                var customers = await _httpClient.GetFromJsonAsync<IEnumerable<Customer>>("Customer");
                if(customers != null)
                {
                    return customers;
                }
                return Enumerable.Empty<Customer>();
              
            }
            catch (Exception)
            {

                return Enumerable.Empty<Customer>();
            }
          
        }
    }
}
