using frontend.Models;

namespace frontend.Data.Contracts
{
    public interface IRentRepo
    {
        /// <summary>
        /// Rents a car asynchronously.
        /// </summary>
        /// <param name="rental">The rental information.</param>
        /// <returns>A task representing the asynchronous operation. The task result is a HttpResponseMessage.</returns>
        Task<HttpResponseMessage> RentCarAsync(Rental rental);

        /// <summary>
        /// Returns a rented car by making an asynchronous HTTP request.
        /// </summary>
        /// <param name="rental">The rental object containing information about the car to be returned.</param>
        /// <returns>A Task object representing the asynchronous operation. The task result should be an HttpResponseMessage object.</returns>
        Task<HttpResponseMessage> ReturnCarAsync(Rental rental);

        /// <summary>
        /// Retrieves all the rented cars asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains an enumerable collection of Rental objects representing all the rented cars.
        /// </returns>
        Task<IEnumerable<Rental>> GetAllRentedCarsAsync();
    }
}
