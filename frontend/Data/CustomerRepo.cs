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
       public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            try
            {
                var customers = await _httpClient.GetFromJsonAsync<Customer>($"Customer/{id}");
                if (customers != null)
                {
                    return customers;
                }
                return null;

            }
            catch (Exception)
            {

                return null;
            }
        }
       public async Task<HttpResponseMessage> CreateCustomerAsync(Customer customer)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<Customer>("Customer", customer);
                return result;



            }
            catch (Exception)
            {

                return new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable);
            }
        }
        public async Task<HttpResponseMessage> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync<Customer>("Customer", customer);
                return result;



            }
            catch (Exception)
            {

                return new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}
