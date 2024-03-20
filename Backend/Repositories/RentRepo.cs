using AutoMapper;
using Backend.Contracts;
using Backend.Models;
using Backend.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class RentRepo : IRentRepo
{
   
    protected CarRentalContext _dbContext;
    internal DbSet<Rental> DbSet { get; set; }

    public RentRepo(CarRentalContext dbContext)
    {
        _dbContext = dbContext;
       
        DbSet = _dbContext.Set<Rental>();
    }

    public async Task<bool> RentCarAsync(Rental rental)
    {
       
        try
        {
            await DbSet.AddAsync(rental);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}