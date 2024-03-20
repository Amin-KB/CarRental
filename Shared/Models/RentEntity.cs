
using Newtonsoft.Json;

namespace Shared.Models;

/// <summary>
/// Represents a rental entity.
/// </summary>
public class RentEntity
{
    [JsonProperty("rentalId")]
    public int RentalId { get; set; }
    [JsonProperty("customer")]
    public CustomerEntity Customer { get; set; }
    [JsonProperty("car")]
    public CarEntity Car { get; set; }
    [JsonProperty("rentalDate")]
    public DateTime? RentalDate { get; set; }
    [JsonProperty("returnDate")]
    public DateTime? ReturnDate { get; set; }
    [JsonProperty("kilometersDriven")]
    public int? KilometersDriven { get; set; }
}