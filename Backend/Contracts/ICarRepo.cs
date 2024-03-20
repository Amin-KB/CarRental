using Backend.Models;
using Backend.Models.Dtos;

namespace Backend.Contracts;

/// <summary>
/// Represents an interface for accessing Car data from a repository.
/// </summary>
public interface ICarRepo:IRepository<Car>
{
    Task<bool> ChangeRentalStatus(bool status,int carId);
    Task<bool> ChangeCarMileage(int kilometerDriven,int carId);
   Task<bool> UpdateCarStatusAndMileage(bool status,int kilometerDriven,int carId);


}