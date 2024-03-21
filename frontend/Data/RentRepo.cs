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
            _httpClient = new HttpClient { BaseAddress = new Uri(Constants.Constant.BaseAddress) };
        }

        /// Sends a rental request for a car asynchronously.
        /// @param rental The Rental object containing the details of the car rental.
        /// @returns A Task that represents the asynchronous operation. The task result is an HttpResponseMessage that contains the HTTP response from the server.
        /// If the rental request is successful, the HttpResponseMessage will contain the response from the server.
        /// If an exception occurs during the rental request or if the server is unavailable, the HttpResponseMessage will have a status code of ServiceUnavailable (503).
        /// @throws None.
        /// /
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

        /// <summary>
        /// Returns a car by sending a POST request to the specified endpoint with the provided rental information.
        /// </summary>
        /// <param name="rental">The rental information to be sent in the request body.</param>
        /// <returns>
        /// A task representing the asynchronous operation, which returns an <see cref="HttpResponseMessage"/>.
        /// This contains the response received from the server.
        /// </returns>
        /// <remarks>
        /// If an exception occurs during the operation, a new <see cref="HttpResponseMessage"/> with the status code
        /// <see cref="System.Net.HttpStatusCode.ServiceUnavailable"/> is returned.
        /// </remarks>
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

        /// <summary>
        /// Retrieves all rented cars.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an enumerable collection of Rental objects if successful; otherwise, an empty enumerable collection.
        /// </returns>
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