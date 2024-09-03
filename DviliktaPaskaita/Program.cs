using DviliktaPaskaita.Models;
using DviliktaPaskaita.Repositories;
using MongoDB.Driver;
using System.Threading.Tasks;
using YourNamespace.Repositories;
using YourNamespace.Services;
using YourNamespace.UI;

namespace YourNamespace
{
    class Program
    {
        private static IMongoDBRepository mongoRepository;

        static async Task Main(string[] args)
        {
           // builder.Services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient(builder.Configuration.GetConnectionString("mongodb+srv://lrogaciov:<password>@clusterleo.snkkwy4.mongodb.net/?retryWrites=true&w=majority&appName=ClusterLeo")));

            var connectionString = "Server=LAPTOP-2I3V8F0J;Database=CarRentalDB;integrated security = true;";

            var carRepository = new CarRepository(connectionString);
            var customerRepository = new CustomerRepository(connectionString);
            var rentalRepository = new RentalRepository(connectionString);
            var mongoRepository = new MongoDBRepository(new MongoClient("mongodb+srv://lrogaciov:Openup90-@clusterleo.snkkwy4.mongodb.net/?retryWrites=true&w=majority&appName=ClusterLeo"));

            var rentService = new RentService(carRepository, customerRepository, rentalRepository, mongoRepository);
            var rentConsoleUI = new RentConsoleUI(rentService);

            await rentConsoleUI.StartAsync();
            //
            //IDatabaseRepository databaseRepository = new DataBaseRepository();
            //databaseRepository.Add
        }
    }
}



