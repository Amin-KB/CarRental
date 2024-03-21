using frontend.Models;

namespace frontend.Data.Contracts
{
    public interface ICarsRepo
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<IEnumerable<CarRentalHistory>> GetCarRentalHistoryAsync(int carId);
        Task<Car> GetCarByIdAsync(int id);
        Task<HttpResponseMessage> CreateCarAsync(Car car);
        Task<HttpResponseMessage> UpdateCarAsync(Car car);
    }
}
