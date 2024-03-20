using Backend.Contracts;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class CarRepo:Repository<Car>,ICarRepo
{
    public CarRepo(CarRentalContext dbContext) : base(dbContext)
    {
    }

    /// <summary>
    /// Asynchronously retrieves a list of car entities from the database.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of car entities.</returns>
    public override async Task<List<Car>> GetEntitiesAsync()
    {
        return await DbSet.ToListAsync();
    }

    /// <summary>
    /// Retrieves a car entity by its id asynchronously.
    /// </summary>
    /// <param name="id">The id of the car entity to retrieve.</param>
    /// <returns>The car entity with the specified id, or null if not found.</returns>
    public override async Task<Car> GetEntityByIdAsync(int id)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.CarId == id);
    }

    /// <summary>
    /// Creates a new entity of type "Car" asynchronously.
    /// </summary>
    /// <param name="car">The car entity to be created.</param>
    /// <returns>A boolean value indicating the success of the operation.</returns>
    public override async Task<bool> CreateEntityAsync(Car car)
    {
        try
        {
            await DbSet.AddAsync(car);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    /// <summary>
    /// Updates the given car entity asynchronously.
    /// </summary>
    /// <param name="car">The car entity to update.</param>
    /// <returns>True if the update is successful; otherwise, false.</returns>
    public override async Task<bool> UpdateEntityAsync(Car car)
    {
        try
        {
            var entity = await DbSet.FirstOrDefaultAsync(x => x.CarId == car.CarId);
            if (entity != null)
            {
                entity.Make = car.Make;
                entity.Mileage = car.Mileage;
                entity.Year = car.Year;
                entity.Mileage = car.Mileage;
                entity.RentalStatus = car.RentalStatus;
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

    public async Task<bool> ChangeRentalStatus(bool status,int carId)
    {
        try
        {
            var entity = await DbSet.FirstOrDefaultAsync(x => x.CarId == carId);
            if (entity != null)
            {
                entity.RentalStatus = status;
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

    public async Task<bool> ChangeCarMileage(int kilometerDriven,int carId)
    {
        try
        {
            var entity = await DbSet.FirstOrDefaultAsync(x => x.CarId == carId);
            if (entity != null)
            {
                entity.Mileage =  entity.Mileage+kilometerDriven;
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