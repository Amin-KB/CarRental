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
    private readonly IMapper _mapper;
    public RentController(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var data = await _unitOfWork.RentRepo.GetRentedCarsAsync();
        return Ok(data);
    }
    [HttpPost]
    public async Task<IActionResult> RentAsync([FromBody]RentalDto dto)
    {
        var rentedCar = new Rental()
        {
            RentalId = dto.RentalId,
            CustomerId = dto.Customer.CustomerId,
            CarId = dto.Car.CarId,
            RentalDate = dto.RentalDate,
            ReturnDate = dto.ReturnDate,
            KilometersDriven = dto.KilometersDriven
        };
        
        var result = await _unitOfWork.RentRepo.RentCarAsync(rentedCar);
        await _unitOfWork.CompleteAsync();
        if (result)
        {
            var updateCarStatus = await _unitOfWork.CarRepo.ChangeRentalStatus(true, dto.Car.CarId);
            await _unitOfWork.CompleteAsync();
        }
        return Ok(result);
    }
    [HttpPost("Return")]
    public async Task<IActionResult> ReturnAsync([FromBody]RentalDto dto)
    {
        var rentedCar = new Rental()
        {
            RentalId = dto.RentalId,
            CustomerId = dto.Customer.CustomerId,
            CarId = dto.Car.CarId,
            RentalDate = dto.RentalDate,
            ReturnDate = dto.ReturnDate,
            KilometersDriven = dto.KilometersDriven
        };
        
        var result = await _unitOfWork.RentRepo.ReturnCarAsync(rentedCar);
        await _unitOfWork.CompleteAsync();
        if (result)
        {
            var updateCarStatus = await _unitOfWork.CarRepo.ChangeRentalStatus(false, dto.Car.CarId);
            var updateCarmileage = await _unitOfWork.CarRepo.ChangeCarMileage((int)dto.KilometersDriven, dto.Car.CarId);
            await _unitOfWork.CompleteAsync();
        }
        return Ok(result);
    }
}