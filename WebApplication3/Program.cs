using DviliktaPaskaita.Repositories;
using MongoDB.Driver;
using Serilog;
using YourNamespace.Repositories;
using YourNamespace.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = "Server=LAPTOP-2I3V8F0J;Database=CarRentalDB;integrated security = true;";

var carRepository = new CarRepository(connectionString);
var customerRepository = new CustomerRepository(connectionString);
var rentalRepository = new RentalRepository(connectionString);
var mongoRepository = new MongoDBRepository(new MongoClient("mongodb+srv://lrogaciov:Openup90-@clusterleo.snkkwy4.mongodb.net/?retryWrites=true&w=majority&appName=ClusterLeo"));

var rentService = new RentService(carRepository, customerRepository, rentalRepository, mongoRepository);
//var rentConsoleUI = new RentConsoleUI(rentService);

builder.Services.AddSingleton<IRentService, RentService>(x => new RentService(carRepository,customerRepository,rentalRepository, mongoRepository));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var log = new LoggerConfiguration()
  //  .WriteTo.Console();
    .WriteTo.File("logs/myapp.txt,", rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Logger = log;
Log.Information("Web app started");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

