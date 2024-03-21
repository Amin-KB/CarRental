using frontend.Data.Contracts;
using frontend.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;

namespace frontend.Data
{
    public class CarRepo : ICarsRepo
    {
        private HttpClient _httpClient;

        public CarRepo()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(Constants.Constant.BaseAddress) };
        }

        /// <summary>
        /// Creates a car asynchronously by sending a POST request to the server
        /// </summary>
        /// <param name="car">The car object to be created</param>
        /// <returns>A Task representing the HTTP response message</returns>
        public async Task<HttpResponseMessage> CreateCarAsync(Car car)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync<Car>("Car", car);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable);
            }
        }

        /// <summary>
        /// Retrieves the car rental history for a given car ID asynchronously.
        /// </summary>
        /// <param name="carId">The ID of the car for which to retrieve the rental history.</param>
        /// <returns>
        /// The car rental history as an enumerable collection of CarRentalHistory objects.
        /// If the car ID is invalid or there is no rental history available, an empty enumerable is returned.
        /// </returns>
        /// <remarks>
        /// This method calls the Car/rentalhistory/{carId} endpoint of the HTTP client to retrieve the rental history.
        /// It handles any exceptions that may occur during the retrieval and returns an empty enumerable in case of an error.
        /// </remarks>
        public async Task<IEnumerable<CarRentalHistory>> GetCarRentalHistoryAsync(int carId)
        {
            try
            {
                var rentalhistory =
                    await _httpClient.GetFromJsonAsync<IEnumerable<CarRentalHistory>>($"Car/rentalhistory/{carId}");
                if (rentalhistory == null)
                {
                    return Enumerable.Empty<CarRentalHistory>();
                }

                return rentalhistory;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return Enumerable.Empty<CarRentalHistory>();
            }
        }

        /// <summary>
        /// Retrieves all cars asynchronously. </summary> <returns>
        /// An enumerable of Car objects representing all the cars retrieved by the method. If no cars are found, an empty enumerable is returned. </returns>
        /// /
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
                if (car == null)
                    return null;
                else
                    return car;
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