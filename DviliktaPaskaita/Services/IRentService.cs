using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using YourNamespace.Models;

namespace YourNamespace.Services
{
    public interface IRentService
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<IEnumerable<OilFuelCar>> GetOilFuelCarsAsync();
        Task<IEnumerable<ElectricCar>> GetElectricCarsAsync();
        Task AddCarAsync(Car car);
        Task UpdateCarAsync(Car car);
        Task DeleteCarAsync(int id);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
        Task<IEnumerable<Rental>> GetAllRentalsAsync();
        Task AddRentalAsync(Rental rental);
        Task<OilFuelCar> GetCarByIdAsync(int carId);
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<OilFuelCar> GetCarByRegistrationNumberAsync(string? registrationNumber);
    }
}