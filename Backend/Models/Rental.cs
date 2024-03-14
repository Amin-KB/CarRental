using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Rental
{
    public int RentalId { get; set; }

    public int? CustomerId { get; set; }

    public int? CarId { get; set; }

    public DateTime? RentalDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public int? KilometersDriven { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
