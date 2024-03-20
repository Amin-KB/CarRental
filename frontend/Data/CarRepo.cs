using frontend.Data.Contracts;
using frontend.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace frontend.Data
{
    public class CarRepo : ICarsRepo
    {
        private HttpClient _httpClient;
        public CarRepo()
        {

            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5202/api/") };

        }
        public async Task<HttpResponseMessage> CreateCarAsync(Car car)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<Car>("Car", car);
                return result;



            }
            catch (Exception)
            {

                return new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable);
            }
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            try
            {
                var cars = await _httpClient.GetFromJsonAsync<IEnumerable<Car>>("Car");
                if (cars != null)
                {
                    return cars;
                }
                return Enumerable.Empty<Car>();

            }
            catch (Exception)
            {

                return Enumerable.Empty<Car>();
            }
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            try
            {
                var car = await _httpClient.GetFromJsonAsync<Car>($"Car/{id}");
                if (car != null)
                {
                    return car;
                }
                return null;

            }
            catch (Exception)
            {

                return null;
            }
        }

        public Task<HttpResponseMessage> UpdateCarAsync(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
