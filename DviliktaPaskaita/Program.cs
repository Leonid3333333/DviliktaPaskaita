using System.Threading.Tasks;
using YourNamespace.Repositories;
using YourNamespace.Services;
using YourNamespace.UI;

namespace YourNamespace
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connectionString = "Server=LAPTOP-2I3V8F0J;Database=CarRentalDB;integrated security = true;";

            var carRepository = new CarRepository(connectionString);
            var customerRepository = new CustomerRepository(connectionString);
            var rentalRepository = new RentalRepository(connectionString);

            var rentService = new RentService(carRepository, customerRepository, rentalRepository);
            var rentConsoleUI = new RentConsoleUI(rentService);

            await rentConsoleUI.StartAsync();
        }
    }
}



