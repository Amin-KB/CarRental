using frontend.Data.Contracts;
using frontend.Models;
using System.Net.Http.Json;

namespace frontend.Data
{
    public class RentRepo : IRentRepo
    {
        private HttpClient _httpClient;
        public RentRepo()
        {

            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5202/api/") };

        }
        public async Task<HttpResponseMessage> RentCarAsync(Rental rental)
        {

            try
            {
                var result = await _httpClient.PostAsJsonAsync<Rental>("Rent", rental);
                return result;



            }
            catch (Exception)
            {

                return new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable);
            }
        }
        public async Task<HttpResponseMessage> ReturnCarAsync(Rental rental)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<Rental>("Rent/Return", rental);
                return result;



            }
            catch (Exception)
            {

                return new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable);
            }
        }
       public async Task<IEnumerable<Rental>> GetAllRentedCarsAsync()
        {
            try
            {
                var cars = await _httpClient.GetFromJsonAsync<IEnumerable<Rental>>("Rent");
                if (cars != null)
                {
                    return cars;
                }
                return Enumerable.Empty<Rental>();

            }
            catch (Exception)
            {

                return Enumerable.Empty<Rental>();
            }
        }
    }
}
