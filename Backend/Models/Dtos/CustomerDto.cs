using Newtonsoft.Json;

namespace Backend.Models.Dtos
{
    public class CustomerDto
    {
        [JsonProperty("customerId")]
        public int? CustomerId { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; } = null!;
        [JsonProperty("lastName")]
        public string LastName { get; set; } = null!;
        [JsonProperty("email")]
        public string Email { get; set; } = null!;
        [JsonProperty("phone")]
        public string Phone { get; set; } = null!;
        [JsonProperty("address")]
        public string? Address { get; set; }
        [JsonProperty("city")]
        public string? City { get; set; }
        [JsonProperty("postal")]
        public string? Postal { get; set; }
        [JsonProperty("region")]
        public string? Region { get; set; }
        [JsonProperty("country")]
        public string? Country { get; set; }
    }
}
