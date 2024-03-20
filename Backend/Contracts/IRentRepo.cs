using Backend.Models;
using Backend.Models.Dtos;

namespace Backend.Contracts;

public interface IRentRepo
{
    /// <summary>
    /// Rent a car asynchronously.
    /// </summary>
    /// <param name="rental">Information about the rental.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains a boolean value indicating
    /// whether the car was successfully rented or not.
    /// </returns>
    Task<bool> RentCarAsync(Rental rental);

    /// <summary>
    /// Returns a rented car for a given rental.
    /// </summary>
    /// <param name="rental">The Rental object representing the car rental details.</param>
    /// <returns>A Task that represents the asynchronous operation. The task result contains a boolean value indicating if the car was successfully returned.</returns>
    /// <remarks>
    /// The ReturnCarAsync method is used to mark a car as returned for the specified rental.
    /// It updates the rental status and performs any necessary actions related to returning the car.
    /// </remarks>
    Task<bool> ReturnCarAsync(Rental rental);

    /// <summary>
    /// Retrieves a list of rented cars asynchronously.
    /// </summary>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains a list of RentalDto objects representing the rented cars.
    /// </returns>
    Task<List<RentalDto>> GetRentedCarsAsync();

    /// <summary>
    /// Retrieves the rental history of a specific customer from the database.
    /// </summary>
    /// <param name="customerId">The unique identifier of the customer.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of CustomerRentHistory objects representing the rental history of the customer.</returns>
    Task<List<CustomerRentHistory>> GetCustomerRentalHistory(int customerId);
}