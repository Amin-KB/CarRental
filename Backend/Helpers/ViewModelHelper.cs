using Backend.Models;
using Backend.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Backend.Helpers;

public static class ViewModelHelper
{
    /// <summary>
    /// Maps the RentalDto data transfer object with data from the CarRental context.
    /// </summary>
    /// <param name="_dbContext">The instance of the CarRentalContext to retrieve data from.</param>
    /// <returns>A list of RentalDto objects mapped from the CarRental context.</returns>
    public static async Task<List<RentalDto>> MapRentalDto(CarRentalContext _dbContext)
    {
        return  (from r in _dbContext.Rentals
            join cu in _dbContext.Customers on r.CustomerId equals cu.CustomerId
            join ca in _dbContext.Cars on r.CarId equals ca.CarId
            select new RentalDto()
            {
                RentalId = r.RentalId,
                RentalDate = r.RentalDate,
                ReturnDate = r.ReturnDate,
                KilometersDriven = r.KilometersDriven,
                Car = new CarDto()
                {
                    CarId = ca.CarId,
                    Make = ca.Make,
                    Model = ca.Model,
                    Year = ca.Year,
                    Mileage = ca.Mileage,
                    RentalStatus = ca.RentalStatus
                },
                Customer = new CustomerDto()
                {
                    CustomerId = cu.CustomerId,
                    FirstName = cu.FirstName,
                    LastName = cu.LastName,
                    Email = cu.Email,
                    Phone = cu.Phone,
                    Address = cu.Address,
                    City = cu.City,
                    Postal = cu.Postal,
                    Region = cu.Region,
                    Country = cu.Country
                 
                }
             
                 
            }).ToList();
       
    }
    public static Rental CreateRentalFromDto(RentalDto dto)
    {
        return new Rental()
        {
            RentalId = dto.RentalId,
            CustomerId = dto.Customer.CustomerId,
            CarId = dto.Car.CarId,
            RentalDate = dto.RentalDate,
            ReturnDate = dto.ReturnDate,
            KilometersDriven = dto.KilometersDriven
        };
    }
}