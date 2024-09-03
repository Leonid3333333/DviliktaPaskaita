using DviliktaPaskaita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourNamespace.Models;
using YourNamespace.Repositories;

namespace DviliktaPaskaita.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        public CustomerDbContext _dbContext;

        public DatabaseRepository()
        {
            _dbContext = new CustomerDbContext();
        }

        public List<Customer> GetCustomers()
        {
            return _dbContext.customers.ToList();
        }

        private readonly RentDbContext _context;

        public DatabaseRepository(RentDbContext context)
        {
            _context = context;
        }

        // Implementing methods for Bicycles
        public IEnumerable<Bicycle> GetBicycles()
        {
            return _context.Bicycles.ToList();
        }

        public Bicycle GetBicycleById(int id)
        {
            return _context.Bicycles.Find(id);
        }

        public void AddBicycle(Bicycle bicycle)
        {
            _context.Bicycles.Add(bicycle);
            _context.SaveChanges();
        }

        public void UpdateBicycle(Bicycle bicycle)
        {
            _context.Bicycles.Update(bicycle);
            _context.SaveChanges();
        }

        public void DeleteBicycle(int id)
        {
            var bicycle = _context.Bicycles.Find(id);
            if (bicycle != null)
            {
                _context.Bicycles.Remove(bicycle);
                _context.SaveChanges();
            }
        }

        // Implementing methods for Bicycle Rentals
    }


}
