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
    [HttpPost]
    public async Task<IActionResult> RentAsync([FromBody]RentalDto dto)
    {
        
        var rental = _mapper.Map<Rental>(dto);
        var car = _mapper.Map<Car>(dto.Car);
        var result = await _unitOfWork.RentRepo.RentCarAsync(rental);
        await _unitOfWork.CompleteAsync();
        if (result)
        {
            var updateCarStatus = await _unitOfWork.CarRepo.UpdateEntityAsync(car);
            await _unitOfWork.CompleteAsync();
        }
        return Ok(result);
    }
}