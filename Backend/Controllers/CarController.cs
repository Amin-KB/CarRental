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
    public CarController(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var _data = await _unitOfWork.CarRepo.GetEntitiesAsync();
        var custommers = _mapper.Map<List<CarDto>>(_data);
        return Ok(custommers);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var _data=await _unitOfWork.CarRepo.GetEntityByIdAsync(id);
        var car = _mapper.Map<CarDto>(_data);
        return Ok(car);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]CarDto dto)
    {
        var car = _mapper.Map<Car>(dto);
        var result = await _unitOfWork.CarRepo.CreateEntityAsync(car);
        await _unitOfWork.CompleteAsync();
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(CarDto dto)
    {
        var car = _mapper.Map<Car>(dto);
        var result = await _unitOfWork.CarRepo.UpdateEntityAsync(car);
        return Ok(result);
    }
}