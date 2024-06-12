using FrontEnd.Pages;
using WebApplication3;
using YourNamespace.Models;

namespace FrontEnd.Services
{
    public interface IRentAPIService
    {
           List<Cars> GetAllCars();
        List<Customer> GetAllCustomer();
        List<Rental> GetAllRentals();
    }
}