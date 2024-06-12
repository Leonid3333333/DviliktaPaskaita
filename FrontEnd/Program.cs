using FrontEnd.Services;
using MongoDB.Driver;
using Serilog;
using YourNamespace.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient(builder.Configuration.GetConnectionString("mongodb+srv://lrogaciov:<password>@clusterleo.snkkwy4.mongodb.net/?retryWrites=true&w=majority&appName=ClusterLeo")));
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IRentAPIService, RentAPIService>(_ => new RentAPIService("http://localhost:5099/"));
var app = builder.Build();

var log = new LoggerConfiguration()
    //  .WriteTo.Console();
    .WriteTo.File("logs/myapp.txt,", rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Logger = log;
Log.Information("FronEnd app started");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
