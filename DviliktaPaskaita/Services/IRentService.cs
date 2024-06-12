using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using YourNamespace.Models;

namespace YourNamespace.Services
{
    public interface IRentService
    {
        Task<IEnumerable<Cars>> GetAllCarsAsync();
        Task<IEnumerable<OilFuelCar>> GetOilFuelCarsAsync();
        Task<IEnumerable<ElectricCar>> GetElectricCarsAsync();
        Task AddCarAsync(Cars car);
        Task UpdateCarAsync(Cars car);
        Task DeleteCarAsync(int id);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
        Task<IEnumerable<Rental>> GetAllRentalsAsync();
        Task AddRentalAsync(Rental rental);
        Task<Cars> GetCarByIdAsync(int carId);
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<bool> IsCarAvailableAsync(int carId, DateTime fromDate, DateTime toDate);

        Task<OilFuelCar> GetCarByRegistrationNumberAsync(string? registrationNumber);
        Task<bool> IsCarAvailableAsync();
        Task<List<Cars>> SearchByMakeOrModelAsync(string searchKey);
        //Task<IEnumerable<Customer>> GetAllAsync();
        Task<List<Customer>> SearchAsync(string searchKey);
        Task<List<Customer>> GetAllAsync();
    }
}