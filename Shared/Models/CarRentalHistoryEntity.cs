namespace Shared.Models;

public class CarRentalHistoryEntity
{
    public int CarId { get; set; }
    public CustomerEntity Customer { get; set; }
    public int RentalId { get; set; }
    public DateTime? RentalDate { get; set; }

    public DateTime? ReturnDate { get; set; }
  
    public int? KilometersDriven { get; set; }
}