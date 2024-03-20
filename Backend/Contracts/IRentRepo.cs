using Backend.Models;
using Backend.Models.Dtos;

namespace Backend.Contracts;

public interface IRentRepo
{
    Task<bool> RentCarAsync(Rental rental);
}