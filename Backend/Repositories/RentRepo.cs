using AutoMapper;
using Backend.Contracts;
using Backend.Models;
using Backend.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class RentRepo : IRentRepo
{
    /// <summary>
    /// The database context for car rental operations.
    /// </summary>
    protected CarRentalContext _dbContext;

    /// <summary>
    /// Gets or sets the internal <see cref="DbSet{TEntity}"/> for rentals.
    /// </summary>
    /// <value>
    /// The internal <see cref="DbSet{TEntity}"/> for rentals.
    /// </value>
    internal DbSet<Rental> DbSet { get; set; }

    public RentRepo(CarRentalContext dbContext)
    {
        _dbContext = dbContext;

        DbSet = _dbContext.Set<Rental>();
    }

    /// <summary>
    /// Asynchronously adds a rental to the database.
    /// </summary>
    /// <param name="rental">The rental object to be added.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// It returns true if the rental is successfully added to the database; otherwise, false.
    /// </returns>
    public async Task<bool> RentCarAsync(Rental rental)
    {
        try
        {
            await DbSet.AddAsync(rental);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    /// <summary>
    /// Gets a list of rented cars for a given customer.
    /// </summary>
    /// <param name="customerId">The ID of the customer.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of Rental objects if the customer has rented cars, otherwise null.</returns>
    public async Task<List<CustomerRentHistory>> GetCustomerRentalHistory(int customerId)
    {
        List<CustomerRentHistory> rentHistory = await _dbContext.Rentals
            .Where(x => x.CustomerId == customerId)
            .Select(rental => new CustomerRentHistory
            {
                RentalId = rental.RentalId,
                CarId = (int)rental.CarId,
                RentalDate = rental.RentalDate,
                ReturnDate = rental.ReturnDate,
                KilometersDriven = rental.KilometersDriven
            })
            .ToListAsync();

        return rentHistory;
    }

    public async Task<List<CarRentalHistory>> GetCarRentalHistory(int carId)
    {
        List<CarRentalHistory> rentHistory = await _dbContext.Rentals
            .Where(x => x.CarId == carId)
            .Select(rental => new CarRentalHistory
            {
                RentalId = rental.RentalId,
                CarId = (int)rental.CarId,
                RentalDate = rental.RentalDate,
                ReturnDate = rental.ReturnDate,
                KilometersDriven = rental.KilometersDriven,

                Customer = new CustomerDto
                {
                    CustomerId = (int)rental.CustomerId,
                    FirstName = rental.Customer.FirstName,
                    LastName = rental.Customer.LastName,
                    Email = rental.Customer.Email,
                    Phone = rental.Customer.Phone,
                    Address = rental.Customer.Address,
                    City = rental.Customer.City,
                    Postal = rental.Customer.Postal,
                    Region = rental.Customer.Region,
                    Country = rental.Customer.Country
                }
            }).ToListAsync();
        return rentHistory;
    }

    public async Task<List<RentalDto>> GetRentedCarsAsync()
    {
        return await Helpers.ViewModelHelper.MapRentalDto(_dbContext);
    }

    /// <summary>
    /// Returns a rented car by setting the return date and kilometers driven.
    /// </summary>
    /// <param name="rental">The rental object representing the rented car.</param>
    /// <returns>A task representing the asynchronous operation. The task result is True if the car is successfully returned, False otherwise.</returns>
    public async Task<bool> ReturnCarAsync(Rental rental)
    {
        try
        {
            var entity = await DbSet.FirstOrDefaultAsync(x => x.RentalId == rental.RentalId);
            if (entity == null)
            {
                Console.WriteLine("Entity is not found");
                return false;
            }

            entity.ReturnDate = rental.ReturnDate;
            entity.KilometersDriven = rental.KilometersDriven;
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

   
}