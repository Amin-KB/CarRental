using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class CarEntity
    {
        public int CarId { get; set; }

        public string? Make { get; set; }

        public string? Model { get; set; }

        public int? Year { get; set; }

        public int? Mileage { get; set; }

        public bool? RentalStatus { get; set; }
    }
}
