﻿using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;
using System.Threading.Tasks;
using YourNamespace.Models;
using YourNamespace.Repositories;

namespace YourNamespace.Services
{
    public class RentService : IRentService
    {
        private readonly ICarRepository _carRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IRentalRepository _rentalRepository;

        public RentService(ICarRepository carRepository, ICustomerRepository customerRepository, IRentalRepository rentalRepository)
        {
            _carRepository = carRepository;
            _customerRepository = customerRepository;
            _rentalRepository = rentalRepository;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync() => await _carRepository.GetAllCarsAsync();

        public async Task<IEnumerable<OilFuelCar>> GetOilFuelCarsAsync() => await _carRepository.GetOilFuelCarsAsync();

        public async Task<IEnumerable<ElectricCar>> GetElectricCarsAsync() => await _carRepository.GetElectricCarsAsync();

        public async Task AddCarAsync(Car car) => await _carRepository.AddCarAsync(car);

        public async Task UpdateCarAsync(Car car) => await _carRepository.UpdateCarAsync(car);

        public async Task DeleteCarAsync(int id) => await _carRepository.DeleteCarAsync(id);

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync() => await _customerRepository.GetAllCustomersAsync();

        public async Task AddCustomerAsync(Customer customer) => await _customerRepository.AddCustomerAsync(customer);

        public async Task UpdateCustomerAsync(Customer customer) => await _customerRepository.UpdateCustomerAsync(customer);

        public async Task DeleteCustomerAsync(int id) => await _customerRepository.DeleteCustomerAsync(id);

        public async Task<IEnumerable<Rental>> GetAllRentalsAsync() => await _rentalRepository.GetAllRentalsAsync();

        public async Task AddRentalAsync(Rental rental)
        {
            var isAvailable = await _rentalRepository.IsCarAvailableAsync(rental.CarId, rental.FromDate, rental.ToDate);
            if (!isAvailable)
                throw new InvalidOperationException("The car is not available for the specified period.");

            await _rentalRepository.AddRentalAsync(rental);
        }

        public Task<OilFuelCar> GetCarByIdAsync(int carId) => _carRepository.GetCarByIdAsync();


        public async Task<Customer> GetCustomerByIdAsync(int customerId) => await _customerRepository.UpdateCustomerAsync();

        public Task<OilFuelCar> GetCarByRegistrationNumberAsync(string? registrationNumber)
        {
            throw new NotImplementedException();
        }
    }
}