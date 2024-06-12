using DviliktaPaskaita.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;
using System.Threading.Tasks;
using YourNamespace.Models;
using YourNamespace.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace YourNamespace.Services
{
    public class RentService : IRentService
    {
        private readonly IMongoDBRepository _mongoRepository;

        private readonly ICarRepository _carRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IRentalRepository _rentalRepository;

        public RentService(ICarRepository carRepository, ICustomerRepository customerRepository, IRentalRepository rentalRepository, IMongoDBRepository mongoRepository)
        {
            _carRepository = carRepository;
            _customerRepository = customerRepository;
            _rentalRepository = rentalRepository;
            _mongoRepository = mongoRepository;
        }

        public async Task<IEnumerable<Cars>> GetAllCarsAsync()
        {
            var result = await _mongoRepository.GetAllCarsAsync();
            if (result == null || !result.Any())
            {
                result = await _carRepository.GetAllCarsAsync();
                await _mongoRepository.AddAllCarsAsync(result);
            }

            return await _carRepository.GetAllCarsAsync();
        }

        public async Task<IEnumerable<OilFuelCar>> GetOilFuelCarsAsync()
        {
            return await _carRepository.GetOilFuelCarsAsync();
        }

        public async Task<IEnumerable<ElectricCar>> GetElectricCarsAsync()
        {
            return await _carRepository.GetElectricCarsAsync();
        }

        public async Task AddCarAsync(Cars car)
        {
            await _carRepository.AddCarAsync(car);
        }

        public async Task UpdateCarAsync(Cars car)
        {
            await _carRepository.UpdateCarAsync(car);
        }

        public async Task DeleteCarAsync(int id)
        {
            await _carRepository.DeleteCarAsync(id);
        }

        //public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        //{
        //    return await _customerRepository.GetAllCustomersAsync();
        //}




        public async Task AddCustomerAsync(Customer customer)
        {
            await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _customerRepository.UpdateCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteCustomerAsync(id);
        }

        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
        {
            return await _rentalRepository.GetAllRentalsAsync();
        }

        public async Task AddRentalAsync(Rental rental)
        {
            var isAvailable = await _rentalRepository.IsCarAvailableAsync(rental.CarId, rental.FromDate, rental.ToDate);
            if (!isAvailable)
                throw new InvalidOperationException("The car is not available for the specified period.");

            await _rentalRepository.AddRentalAsync(rental);

        }
        async Task<bool> IRentService.IsCarAvailableAsync(int carId, DateTime fromDate, DateTime toDate)
        {
            return await _rentalRepository.IsCarAvailableAsync(carId, fromDate, toDate);
        }

        public Task<Cars> GetCarByIdAsync(int carId)
        {
            return _carRepository.GetCarByIdAsync(carId);
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _customerRepository.GetCustomerByIdAsync(customerId);
        }

        public Task<OilFuelCar> GetCarByRegistrationNumberAsync(string? registrationNumber)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rental>?> GetAllRentalAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsCarAvailableAsync()
        {
            return await _rentalRepository.IsCarAvailableAsync();
        }

        public async Task<List<Cars>> SearchByMakeOrModelAsync(string searchKey)
        {
            return await _mongoRepository.SearchByMakeOrModelAsync(searchKey);
        }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var result = await _mongoRepository.GetAllCustomersAsync();
            if (result == null || !result.Any())
            {
                result = await _customerRepository.GetAllCustomersAsync();
                await _mongoRepository.AddAllCustomersAsync(result);
            }
            return result;

        }

        public async Task<List<Customer>> SearchAsync(string searchKey)
        {
            return await _mongoRepository.SearchAsync(searchKey);
        }


        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _mongoRepository.GetAllCustomersAsync();
        }

        Task<List<Customer>> IRentService.GetAllAsync()
        {
           return _mongoRepository.GetAllAsync();
        }
    }
}


