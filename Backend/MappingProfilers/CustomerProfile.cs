using AutoMapper;
using Backend.Models;
using Backend.Models.Dtos;

namespace Backend.MappingProfilers
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            
           CreateMap<Customer, CustomerDto>();
        }
    }
}
