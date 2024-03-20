using AutoMapper;
using Backend.Models;
using Backend.Models.Dtos;

namespace Backend.MappingProfilers
{
    /// <summary>
    /// This class represents a customer profile that maps a customer entity to a customer DTO and vice versa.
    /// </summary>
    public class CustomerProfile:Profile
    {
        /// <summary>
        /// Initializes a new instance of the CustomerProfile class.
        /// </summary>
        public CustomerProfile()
        {
            
           CreateMap<Customer, CustomerDto>();
           CreateMap<CustomerDto, Customer>();
        }
    }
}
