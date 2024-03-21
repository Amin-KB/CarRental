using System.Diagnostics;
using frontend.Data.Contracts;
using frontend.Models;
using System.Net.Http.Json;

namespace frontend.Data
{
    public class CustomerRepo : ICustomerRepo
    {
        private HttpClient _httpClient;

        public CustomerRepo()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(Constants.Constant.BaseAddress) };
        }

        /// <summary>
        /// Retrieves all customers from the server.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation.
        /// The task result contains an enumerable of Customer objects.
        /// </returns>
        /// <remarks>
        /// If no customers are found, an empty IEnumerable of Customer objects is returned.
        /// If an exception occurs while retrieving customers, an empty IEnumerable of Customer objects is returned.
        /// </remarks>
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            try
            {
                var customers = await _httpClient.GetFromJsonAsync<IEnumerable<Customer>>("Customer");
                if (customers == null)
                    return Enumerable.Empty<Customer>();
                else
                    return customers;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return Enumerable.Empty<Customer>();
            }
        }

        /// <summary>
        /// Retrieves a customer by their ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>Returns a Task representing the asynchronous operation. The Task's result is the retrieved customer object, or null if the customer does not exist or an error occurred.</returns>
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            try
            {
                var customers = await _httpClient.GetFromJsonAsync<Customer>($"Customer/{id}");
                if (customers == null)
                    return null;
                else
                    return customers;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// , the HttpResponseMessage object will contain the response from the server. If an exception occurs or the server is unavailable, a HttpResponseMessage object with a status code of Service
        /// Unavailable will be returned.
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

        /// <summary>
        /// Updates a customer asynchronously.
        /// </summary>
        /// <param name="customer">The customer object to be updated.</param>
        /// <returns>A task that represents the asynchronous update operation.</returns>
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