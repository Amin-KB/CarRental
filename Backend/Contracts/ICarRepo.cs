using Backend.Models;

namespace Backend.Contracts;

/// <summary>
/// Represents an interface for accessing Car data from a repository.
/// </summary>
public interface ICarRepo:IRepository<Car>
{
    
}