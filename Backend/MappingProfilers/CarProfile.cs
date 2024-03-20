using AutoMapper;
using Backend.Models;
using Backend.Models.Dtos;

namespace Backend.MappingProfilers;

/// <summary>
/// Represents a mapping profile for Car and CarDto.
/// </summary>
public class CarProfile:Profile
{
    /// <summary>
    /// Represents a mapping profile for the CarDto class.
    /// </summary>
    public CarProfile()
    {
        CreateMap<Car, CarDto>();
        CreateMap<CarDto, Car>();
    }
}