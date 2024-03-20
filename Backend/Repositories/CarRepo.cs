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
            return await TryUpdateEntityAsync(car);

            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    /// <summary>
    /// Tries to update the specified car entity in the database.
    /// </summary>
    /// <param name="car">The car entity to update.</param>
    /// <returns>
    /// Returns a task with a boolean value indicating whether the update operation was successful.
    /// The task will have a value of true if the car entity was found and updated, otherwise it will have a value of false.
    /// </returns>
    private async Task<bool> TryUpdateEntityAsync(Car car)
    {
        var databaseCar = await DbSet.FirstOrDefaultAsync(x => x.CarId == car.CarId);
        if (databaseCar != null)
        {
            databaseCar.Make = car.Make;
            databaseCar.Mileage = car.Mileage;
            databaseCar.Year = car.Year;
            databaseCar.Mileage = car.Mileage;
            databaseCar.RentalStatus = car.RentalStatus;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Changes the rental status of a car.
    /// </summary>
    /// <param name="status">The new rental status to be set.</param>
    /// <param name="carId">The ID of the car.</param>
    /// <returns>
    /// A task with a boolean value indicating whether the rental status of the car was successfully changed or not.
    /// <br />True: Rental status changed successfully.
    /// <br />False: An error occurred or the car was not found.
    /// </returns>
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

    /// <summary>
    /// Updates the status and mileage of a car.
    /// </summary>
    /// <param name="status">The new status of the car.</param>
    /// <param name="kilometerDriven">The number of kilometers driven by the car.</param>
    /// <param name="carId">The ID of the car to update.</param>
    /// <returns>Returns true if the update was successful, or false if there was an error or the car does not exist.</returns>
    public async   Task<bool> UpdateCarStatusAndMileage(bool status, int kilometerDriven, int carId)
    {
        try
        {
            var entity = await DbSet.FirstOrDefaultAsync(x => x.CarId == carId);
            if (entity != null)
            {
                entity.RentalStatus = status;
                entity.Mileage = + kilometerDriven;
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

    /// <summary>
    /// Changes the mileage of a car based on the kilometers driven.
    /// </summary>
    /// <param name="kilometerDriven">The number of kilometers driven.</param>
    /// <param name="carId">The ID of the car.</param>
    /// <returns>Returns a boolean value indicating whether the mileage was successfully changed or not.</returns>
    public async Task<bool> ChangeCarMileage(int kilometerDriven,int carId)
    {
        try
        {
            var entity = await DbSet.FirstOrDefaultAsync(x => x.CarId == carId);
            if (entity != null)
            {
                entity.Mileage =  +kilometerDriven;
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