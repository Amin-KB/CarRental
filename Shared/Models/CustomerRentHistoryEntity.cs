using Newtonsoft.Json;

namespace Shared.Models;

public class CustomerRentHistoryEntity
{
   
    public int RentalId { get; set; }

    public int CarId { get; set; }
  
    public DateTime? RentalDate { get; set; }
 
    public DateTime? ReturnDate { get; set; }
 
    public int? KilometersDriven { get; set; }
}