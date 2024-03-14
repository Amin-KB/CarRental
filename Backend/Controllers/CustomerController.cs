using AutoMapper;
using Backend.Contracts;
using Backend.Models;
using Backend.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var _data=await _unitOfWork.CustomerRepo.GetEntitiesAsync();
            var custommers = _mapper.Map<List<CustomerDto>>(_data);
            return Ok(custommers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var _data=await _unitOfWork.CustomerRepo.GetEntityByIdAsync(id);
            var custommer = _mapper.Map<CustomerDto>(_data);
            return Ok(custommer);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            var result = await _unitOfWork.CustomerRepo.CreateEntityAsync(customer);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            var result = await _unitOfWork.CustomerRepo.UpdateEntityAsync(customer);
            return Ok(result);
        }
    }
}
