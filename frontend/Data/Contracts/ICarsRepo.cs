using frontend.Models;

namespace frontend.Data.Contracts
{
    public interface ICarsRepo
    {
        /// <summary>
        /// Retrieves all cars asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the collection of cars.
        /// </returns>
        /// <remarks>
        /// This method retrieves all the cars available in the system.
        /// It returns a task that represents the asynchronous operation.
        /// The task result contains the collection of cars.
        /// </remarks>
        Task<IEnumerable<Car>> GetAllCarsAsync();

        /// <summary>
        /// Retrieves the rental history for a specific car asynchronously.
        /// </summary>
        /// <param name="carId">The ID of the car.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// an enumerable collection of <see cref="CarRentalHistory"/> objects.
        /// </returns>
        Task<IEnumerable<CarRentalHistory>> GetCarRentalHistoryAsync(int carId);

        /// <summary>
        /// Retrieves a car object asynchronously by its ID.
        /// </summary>
        /// <param name="id">The ID of the car to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The task result is a car object.</returns>
        Task<Car> GetCarByIdAsync(int id);

        /// <summary>
        /// Creates a new car asynchronously.
        /// </summary>
        /// <param name="car">The car object to be created.</param>
        /// <returns>A Task object representing the asynchronous operation. The task will contain the HttpResponseMessage when completed.</returns>
        Task<HttpResponseMessage> CreateCarAsync(Car car);

        /// <summary>
        /// Updates a car in the system asynchronously.
        /// </summary>
        /// <param name="car">The car object containing the updated information.</param>
        /// <returns>A task representing the asynchronous operation, returning an HttpResponseMessage.</returns>
        Task<HttpResponseMessage> UpdateCarAsync(Car car);
    }
}
