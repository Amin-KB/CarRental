using AutoMapper;
using Backend.Contracts;
using Backend.Models;
using Backend.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class RentRepo : IRentRepo
{
   
    protected CarRentalContext _dbContext;
    internal DbSet<Rental> DbSet { get; set; }

    public RentRepo(CarRentalContext dbContext)
    {
        _dbContext = dbContext;
       
        DbSet = _dbContext.Set<Rental>();
    }

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
    var rentHistory=await _dbContext.Rentals.Where(x => x.CustomerId == customerId).ToListAsync();
    if (rentHistory != null)
    {
        return rentHistory.Select(rental => new CustomerRentHistory
        {
         
            RentalId = rental.RentalId,
            CarId =(int)rental.CarId,
            RentalDate = rental.RentalDate,
            ReturnDate = rental.ReturnDate,
            KilometersDriven = rental.KilometersDriven
        }).ToList();
    }
      
    else
        return null;
   }
   public async Task<List<RentalDto>> GetRentedCarsAsync()
   {
       return await Helpers.ViewModelHelper.MapRentalDto(_dbContext);
   }

    public async Task<bool> ReturnCarAsync(Rental rental)
   {
       try
       {
           var entity = await DbSet.FirstOrDefaultAsync(x => x.RentalId == rental.RentalId);
           if (entity != null)
           {
               entity.ReturnDate = rental.ReturnDate;
               entity.KilometersDriven = rental.KilometersDriven;

               return true;
           }

           return false;
       }
       catch (Exception e)
       {
           Console.WriteLine(e);
           return false;
       }
   }
}