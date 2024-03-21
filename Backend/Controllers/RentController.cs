using AutoMapper;
using Backend.Contracts;
using Backend.Models;
using Backend.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<RentController> _logger;

    public RentController(IUnitOfWork unitOfWork, ILogger<RentController> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        _logger.LogInformation("Getting all Rented Cars");
        var rentedCars = await _unitOfWork.RentRepo.GetRentedCarsAsync();
        _logger.LogInformation($"{rentedCars.Count()} rented cars has been found ");
        return Ok(rentedCars);
    }
  
    [HttpPost]
    public async Task<IActionResult> RentAsync([FromBody] RentalDto dto)
    {
        _logger.LogInformation(
            $"Renting car process {dto.RentalId} with Id {dto.Car.CarId} for customer with id {dto.Customer.CustomerId}");
        var rentedCar = Helpers.ViewModelHelper.CreateRentalFromDto(dto);

        var result = await _unitOfWork.RentRepo.RentCarAsync(rentedCar);

        if (result)
        {
            await _unitOfWork.CarRepo.ChangeRentalStatus(true, dto.Car.CarId);
            _logger.LogInformation(
                $"Renting car process {dto.RentalId} with Id {dto.Car.CarId} for customer with id {dto.Customer.CustomerId} was successful");
            await _unitOfWork.CompleteAsync();
            return Ok(result);
        }

        _logger.LogWarning(
            $"Renting car process {dto.RentalId} with Id {dto.Car.CarId} for customer with id {dto.Customer.CustomerId} failed");
        return BadRequest("Failed to rent the car");
    }

    [HttpPost("Return")]
    public async Task<IActionResult> ReturnAsync([FromBody] RentalDto dto)
    {
        _logger.LogInformation(
            $"Returning car process {dto.RentalId} with Id {dto.Car.CarId} for customer with id {dto.Customer.CustomerId}");
        var rentedCarEntity = Helpers.ViewModelHelper.CreateRentalFromDto(dto);
        var result = await _unitOfWork.RentRepo.ReturnCarAsync(rentedCarEntity);
       
        if (result)
        {
            _logger.LogInformation(
                $"Returning car process {dto.RentalId} with Id {dto.Car.CarId} for customer with id {dto.Customer.CustomerId} was successful");
            await _unitOfWork.CarRepo.UpdateCarStatusAndMileage(false, (int)dto.KilometersDriven, dto.Car.CarId);
            await _unitOfWork.CompleteAsync();
            return Ok(result);
        }
        _logger.LogWarning(
            $"Returning car process {dto.RentalId} with Id {dto.Car.CarId} for customer with id {dto.Customer.CustomerId} failed");
        return BadRequest("Failed to Returning the car");
    }
}