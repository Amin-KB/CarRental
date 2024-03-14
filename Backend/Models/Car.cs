using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Car
{
    public int CarId { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public int? Year { get; set; }

    public int? Mileage { get; set; }

    public bool? RentalStatus { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual ICollection<Rental> RentalsNavigation { get; set; } = new List<Rental>();
}
