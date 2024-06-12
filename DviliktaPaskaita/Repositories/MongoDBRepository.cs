using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourNamespace.Models;
using static DviliktaPaskaita.Repositories.MongoDBRepository;

namespace DviliktaPaskaita.Repositories
{
    public class MongoDBRepository : IMongoDBRepository
    {


        private IMongoCollection<Cars> _Cars;
        private IMongoCollection<Customer> _customers;

        public MongoDBRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Cars");
            _Cars = database.GetCollection<Cars>("Cars");
            _customers = database.GetCollection<Customer>("Customer");

        }

        public async Task<List<Cars>> GetAllAsync()
        {
            return await _Cars.Find(car => true).ToListAsync();
        }


        public Task AddAllCarAsync(object result)
        {
            throw new NotImplementedException();
        }

        public async Task AddAllCarsAsync(IEnumerable<Cars> cars)
        {
            await _Cars.InsertManyAsync(cars);
        }
        public async Task AddAllCustomersAsync(IEnumerable<Customer> costumers)
        {
            await _customers.InsertManyAsync(costumers);
        }

        public async Task<IEnumerable<Cars>> GetAllCarsAsync()
        {
            return await _Cars.Find(car => true).ToListAsync();
        }
        //public async Task<Cars> GetByIdAsync(string id)
        //{
        //    return await _Cars.Find<Cars>(car => car.Id == id).FirstOrDefaultAsync();
        //}
        public async Task<List<Cars>> SearchByMakeOrModelAsync(string searchKey)
        {
            var filter = Builders<Cars>.Filter.Or(
                Builders<Cars>.Filter.Regex("Make", new MongoDB.Bson.BsonRegularExpression(searchKey, "i")),
                Builders<Cars>.Filter.Regex("Model", new MongoDB.Bson.BsonRegularExpression(searchKey, "i"))
            );
            return await _Cars.Find(filter).ToListAsync();
        }

        public Task<List<Cars>> SearchByMakeOrModelAsync()
        {
            throw new NotImplementedException();
        }

         async Task<List<Customer>> IMongoDBRepository.GetAllAsync()
        {
            return await _customers.Find(customer => true).ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
          return  await _customers.Find(customer => true).ToListAsync();
        }

        public async Task<List<Customer>> SearchAsync(string searchKey)
        {
            var filter = Builders<Customer>.Filter.Or(
                Builders<Customer>.Filter.Regex("Name", new BsonRegularExpression(searchKey, "i")),
                Builders<Customer>.Filter.Regex("Email", new BsonRegularExpression(searchKey, "i")),
                Builders<Customer>.Filter.Regex("PhoneNumber", new BsonRegularExpression(searchKey, "i"))
            );
            return await _customers.Find(filter).ToListAsync();
        }



    }
}
