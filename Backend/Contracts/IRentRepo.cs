using Backend.Models;
using Backend.Models.Dtos;

namespace Backend.Contracts;

public interface IRentRepo
{
    Task<bool> RentCarAsync(Rental rental);
    Task<bool> ReturnCarAsync(Rental rental);
    Task<List<RentalDto>> GetRentedCarsAsync();
    Task<List<CustomerRentHistory>> GetCustomerRentalHistory(int customerId);
}