using AutoMapper;
using Backend.Models;
using Backend.Models.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Backend.MappingProfilers;

public class RentalProfile:Profile
{
    public RentalProfile()
    {
        CreateMap<RentalDto, Rental>().ForMember(dest => dest.CustomerId,
                src => src.MapFrom(x => x.Customer.CustomerId))
            .ForMember(dest => dest.CarId, src => src.MapFrom(x => x.Car.CarId))
            .ForMember(des => des.RentalId, src => src.MapFrom(x => x.RentalId))
            .ForMember(dest => dest.RentalDate, src => src.MapFrom(x => x.RentalDate))
            .ForMember(dest => dest.ReturnDate, src => src.MapFrom(x => x.ReturnDate))
            .ForMember(dest => dest.KilometersDriven, src => src.MapFrom(x => x.KilometersDriven));
    }
}