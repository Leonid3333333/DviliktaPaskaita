using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourNamespace.Models;

namespace DviliktaPaskaita.Repositories
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> customers {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-2I3V8F0J;Database=CarRentalDB;integrated security = true;TrustServerCertificate=true;");
        }

    }
}
