using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Postal { get; set; }

    public string? Region { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
