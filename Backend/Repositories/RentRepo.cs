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

   public async Task<List<RentalDto>> GetRentedCarsAsync()
   {
     // return _dbContext.Rentals.Include(x => x.Customer).Include(x => x.Car).ToList();
     var query = (from r in _dbContext.Rentals
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
     return query;
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