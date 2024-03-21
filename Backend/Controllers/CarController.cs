using AutoMapper;
using Backend.Contracts;
using Backend.Models;
using Backend.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CarController> _logger;
    public CarController(IUnitOfWork unitOfWork,IMapper mapper,ILogger<CarController> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        _logger.LogInformation("Request started (GetAllAsync)");
        var data = await _unitOfWork.CarRepo.GetEntitiesAsync();
        _logger.LogInformation($"{data.Count()} car has been found ");
        var cars = _mapper.Map<List<CarDto>>(data);
        return Ok(cars);
    }
    [HttpGet("rentalhistory/{carId}")]
    public async Task<IActionResult> RentalHistory(int carId)
    {
        _logger.LogInformation($"Getting rental history for Car with ID {carId}");
        var carRentalHistoriesEntity=await _unitOfWork.RentRepo.GetCarRentalHistory(carId);
        if (carRentalHistoriesEntity != null)
        {
            _logger.LogInformation($"Found rental history for Car with ID {carId}" );
            return Ok(carRentalHistoriesEntity);
        }
        _logger.LogWarning($"No rental history found for Car with ID {carId}");
        return NotFound();


    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        _logger.LogInformation("Request started (GetAsync)");
        var data=await _unitOfWork.CarRepo.GetEntityByIdAsync(id);
        if (data == null)
        {
            _logger.LogError("no car with id {id} exists");
            return new NotFoundResult();
        }
        _logger.LogInformation(" car with id {id} has been found");
        var car = _mapper.Map<CarDto>(data);
        return Ok(car);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]CarDto dto)
    {
        _logger.LogInformation("Request started (CreateAsync)");
        var car = _mapper.Map<Car>(dto);
        var result = await _unitOfWork.CarRepo.CreateEntityAsync(car);
        if (result != true)
        {
            _logger.LogError("no car with id {id} could be created");
            return BadRequest();
        }
        await _unitOfWork.CompleteAsync();
        _logger.LogInformation(" car with id {id} has been created");
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(CarDto dto)
    {
        _logger.LogInformation("Request started (UpdateAsync)");
        var car = _mapper.Map<Car>(dto);
        var result = await _unitOfWork.CarRepo.UpdateEntityAsync(car);
        if (result != true)
        {
            _logger.LogError("car with id {id} could be updated");
            return BadRequest();
        }
        await _unitOfWork.CompleteAsync();
        _logger.LogInformation(" car with id {id} has been updated");
        return Ok(result);
    }
    [HttpDelete("{carId}")]
    public async Task<IActionResult> DeleteAsync(int carId)
    {
        _logger.LogInformation($"Deleting car with ID {carId}.");
        var result = await _unitOfWork.CarRepo.DeleteEntityAsync(carId);
        if (result)
        {
            await _unitOfWork.CompleteAsync();
            _logger.LogInformation($"Deleting car with ID {carId} was successful");
            return Ok(result);
        }
        _logger.LogWarning($"Deleting car with ID {carId} was not successful");
        return BadRequest();
    }
}