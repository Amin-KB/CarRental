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
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(IUnitOfWork unitOfWork,IMapper mapper,ILogger<CustomerController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            _logger.LogInformation("Getting all customers");
            var customersEntity=await _unitOfWork.CustomerRepo.GetEntitiesAsync();
            var customersDto = _mapper.Map<List<CustomerDto>>(customersEntity);
            _logger.LogInformation($"Returning {customersDto.Count} customers");
            return Ok(customersDto);
        }
        [HttpGet("rentalhistory/{customerId}")]
        public async Task<IActionResult> RentalHistory(int customerId)
        {
            _logger.LogInformation($"Getting rental history for customer with ID {customerId}");
            var customerRentalHistoriesEntity=await _unitOfWork.RentRepo.GetCustomerRentalHistory(customerId);
            if (customerRentalHistoriesEntity != null)
            {
                _logger.LogInformation($"Found rental history for customer with ID {customerId}" );
                return Ok(customerRentalHistoriesEntity);
            }
            _logger.LogWarning($"No rental history found for customer with ID {customerId}");
            return NotFound();


        }
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetAsync(int customerId)
        {
            _logger.LogInformation($"Getting  customer Info with ID {customerId}");
            var customerEntity=await _unitOfWork.CustomerRepo.GetEntityByIdAsync(customerId);
            if (customerEntity != null)
            {
                var customerDto = _mapper.Map<CustomerDto>(customerEntity);
                _logger.LogInformation($"customer Info with ID {customerId} was found");
                return Ok(customerDto);
            }
            _logger.LogWarning($"No customer with ID {customerId} was found");
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]CustomerDto dto)
        {
            var customerEntity = _mapper.Map<Customer>(dto);
            var result = await _unitOfWork.CustomerRepo.CreateEntityAsync(customerEntity);
            if (result)
            {
                await _unitOfWork.CompleteAsync();
                return Ok(result);
            }

            return BadRequest();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CustomerDto dto)
        {
            _logger.LogInformation($"Create Customer with ID {dto.CustomerId}.");
            var customerEntity = _mapper.Map<Customer>(dto);
            var result = await _unitOfWork.CustomerRepo.UpdateEntityAsync(customerEntity);
            if (result)
            {
                await _unitOfWork.CompleteAsync();
                _logger.LogInformation($"Creating Customer with ID {dto.CustomerId} was successful");
                return Ok(result);
            }
            _logger.LogWarning($"Creating Customer with ID {dto.CustomerId} was not successful");
            return BadRequest();
         
        }
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteAsync(int customerId)
        {
            _logger.LogInformation($"Deleting Customer with ID {customerId}.");
            var result = await _unitOfWork.CustomerRepo.DeleteEntityAsync(customerId);
            if (result)
            {
                await _unitOfWork.CompleteAsync();
                _logger.LogInformation($"Deleting Customer with ID {customerId} was successful");
                return Ok(result);
            }
            _logger.LogWarning($"Deleting Customer with ID {customerId} was not successful");
            return BadRequest();
        }
    }
}
