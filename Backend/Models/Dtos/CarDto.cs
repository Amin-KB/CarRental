namespace Backend.Models.Dtos;

public class CarDto
{
    public int CarId { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public int? Year { get; set; }

    public int? Mileage { get; set; }

    public bool? RentalStatus { get; set; }
}