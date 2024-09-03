using DviliktaPaskaita.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourNamespace.Models;

namespace DviliktaPaskaita.Repositories
{
   public class RentDbContext : DbContext
    {
        public RentDbContext(DbContextOptions<RentDbContext> options) : base(options)
        {
        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<OilFuelCar> OilFuelCars { get; set; }
        public DbSet<ElectricCar> ElectricCars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Bicycle> Bicycles { get; set; }
        //public DbSet<BicycleRental> BicycleRentals { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OilFuelCar>()
        //        .HasOne<Car>()
        //        .WithOne()
        //        .HasForeignKey<OilFuelCar>(e => e.Id);

        //    modelBuilder.Entity<ElectricCar>()
        //        .HasOne<Car>()
        //        .WithOne()
        //        .HasForeignKey<ElectricCar>(e => e.Id);
        //}
    }
}
