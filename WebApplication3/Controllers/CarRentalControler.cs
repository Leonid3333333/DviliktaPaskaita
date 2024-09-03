using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using static DviliktaPaskaita.Repositories.MongoDBRepository;

using YourNamespace.Models;
using YourNamespace.Services;
using WebApplication3.Repositories;
using Serilog;
using Microsoft.EntityFrameworkCore;
using DviliktaPaskaita.Repositories;

namespace WebApplication3.Controllers
{
    public class RentServiceControler : Controller
    {
        private readonly IRentService _rentService;
        private readonly IDatabaseRepository _repository;

        public RentServiceControler(IRentService rentService)
        {
            _rentService = rentService;
        }


        [HttpGet("GetAllCars")]
        public async Task<IActionResult> GetAllCarsAsync()
        {
            try
            {
                Log.Information("All info succesfully loaded");
                var categories = await _rentService.GetAllCarsAsync();
                return Ok(categories);

            }
            catch (Exception ex)
            {
                Log.Error("Failed to get cars");
                return BadRequest(ex.Message);
            }
            //return await _rentService.GetAllCarsAsync();
        }


        [HttpGet("GetAllElectrivVehicles")]
        public async Task<IEnumerable<ElectricCar>?> GetElectricCarsAsync()
        {
            return await _rentService.GetElectricCarsAsync();
        }


        [HttpGet("GetAllOilFuelCars")]
        public async Task<IEnumerable<OilFuelCar>?> GetAllOilFuelVehicles()
        {
            return await _rentService.GetOilFuelCarsAsync();
        }

        [HttpGet("GetAllCostumres")]
        public IEnumerable<Customer> GetAllCostumres()
        {
            return _rentService.GetAllCustomersAsync().Result;
        }


        [HttpPost("UpdateCar")]
        public async Task UpdateCarAsync(Cars car)
        {
            await _rentService.UpdateCarAsync(car);
        }


        [HttpPost("AddCar")]
        public async Task AddCarAsync([FromForm] Cars car)
        {
            await _rentService.AddCarAsync(car);
        }

        [HttpPost("AddCustomer")]
        public async Task AddCustomerAsync([FromForm] Customer customer)
        {
            await _rentService.AddCustomerAsync(customer);
        }

        [HttpPost("DeleteCar")]
        public async Task DeleteCarAsync(int id)
        {
            await _rentService.DeleteCarAsync(id);
        }

        [HttpPost("DeleteCostumer")]
        public async Task DeleteCustomerAsync(int id)
        {
            await _rentService.DeleteCustomerAsync(id);
        }

        [HttpPost("UpdateCostumer")]
        public async Task UpdateCustomerAsync([FromForm] Customer customer)
        {
            await _rentService.UpdateCustomerAsync(customer);
        }

        [HttpPost("RentCar")]
        public async Task AddRentalAsync([FromForm] Rental rental)
        {
            await _rentService.AddRentalAsync(rental);
        }

        [HttpGet("GetAllRentals")]
        public async Task<IEnumerable<Rental>?> GetAllRentalsAsync()
        {
            return await _rentService.GetAllRentalsAsync();
        }

        [HttpPost("GetCarById")]
        public Task<Cars> GetCarByIdAsync(int carId)
        {
            return _rentService.GetCarByIdAsync(carId);
        }


        [HttpGet("Mongo Car search ")]
        public async Task<ActionResult<List<Cars>>> SearchByMakeOrModelAsync([FromQuery] string searchKey)
        {
            var cars = await _rentService.SearchByMakeOrModelAsync(searchKey);

            if (cars == null)
            {
                return NotFound();
            }

            return Ok(cars);
        }

        [HttpGet("Mongo Customers search")]
        public async Task<ActionResult<IEnumerable<Customer>>> Search([FromQuery] string key)
        {
            var customers = await _rentService.SearchAsync(key);
            return Ok(customers);
        }

        [HttpGet("GetAllCustomersFromMongo")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllAsync()
        {
            var customers = await _rentService.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("GetAllCustomersIntity")]
        public IActionResult GetCustomers()
        {
            var customers = _repository.GetCustomers();
            return Ok(customers);
        }
        //[HttpGet]
        //public IActionResult GetCustomers()
        //{
        //    var customers = _dbContext.customers.ToList();
        //    _.GetCustomers();
        //    return Ok(customers);
        //}

        //[HttpPost]
        //public async Task<ActionResult> Create(Carz car)
        //{
        //    await _carRepository.CreateAsync(car);
        //    return CreatedAtAction(nameof(Get), new { id = car.Id }, car);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(string id, Car carIn)
        //{
        //    var car = await _rentService.GetByIdAsync(id);

        //    if (car == null)
        //    {
        //        return NotFound();
        //    }

        //    await _carRepository.UpdateAsync(id, carIn);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(string id)
        //{
        //    var car = await _carRepository.GetByIdAsync(id);

        //    if (car == null)
        //    {
        //        return NotFound();
        //    }

        //    await _carRepository.RemoveAsync(id);
        //    return NoContent();
        //}

        //// New search endpoint
        //[HttpGet("search")]
        //public async Task<ActionResult<List<Car>>> Search([FromQuery] string searchKey)
        //{
        //    var cars = await _carRepository.SearchByMakeOrModelAsync(searchKey);

        //    if (cars == null || cars.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(cars);
        //}

        //[HttpGet("search")]
        //public async Task<ActionResult<IEnumerable<Car>>> Search(string CaId)
        //{
        //    var Id = await _carRepository.GetByIdAsync(Id);
        //    return Ok(Id);
        //}




        //[HttpGet("GetCars}")]
        //public async Task<Cars> GetAllCarsAsync() { }
        //{
        //try
        //{
        //    var category = await _categoryRepository.GetByIdAsync(new ObjectId(id));
        //    if (category == null)
        //        return NotFound();

        //    await _categoryRepository.DeleteAsync(new ObjectId(id));
        //    return NoContent();
        //}
        //catch (Exception ex)
        //{
        //    return BadRequest(ex.Message);
        //}







    }
}
