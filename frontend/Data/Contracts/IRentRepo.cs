using frontend.Models;

namespace frontend.Data.Contracts
{
    public interface IRentRepo
    {
        Task<HttpResponseMessage> RentCarAsync(Rental rental);
        Task<HttpResponseMessage> ReturnCarAsync(Rental rental);
        Task<IEnumerable<Rental>> GetAllRentedCarsAsync();
    }
}
