using System.Collections.Generic;
using System.Threading.Tasks;
using YourNamespace.Models;

namespace YourNamespace.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Cars>> GetAllCarsAsync();
        Task<IEnumerable<OilFuelCar>> GetOilFuelCarsAsync();
        Task<IEnumerable<ElectricCar>> GetElectricCarsAsync();
        Task<Cars> GetCarByIdAsync(int id);
        Task AddCarAsync(Cars car);
        Task UpdateCarAsync(Cars car);
        Task DeleteCarAsync(int id);
        Task<OilFuelCar> GetCarByIdAsync();
        Task GetAllCustomersAsync();
    }
}
