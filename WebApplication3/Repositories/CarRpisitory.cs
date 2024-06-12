using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using YourNamespace.Models;

namespace WebApplication3.Repositories
{
    public class CarRepository
    {
        private readonly IMongoCollection<Cars> _cars;

        public CarRepository(IMongoDatabase database)
        {
            _cars = database.GetCollection<Cars>("Cars");
        }

        public async Task<List<Cars>> GetAllAsync()
        {
            return await _cars.Find(car => true).ToListAsync();
        }

        //public async Task<Cars> GetByIdAsync(string id)
        //{
        //    return await _cars.Find<Carz>(car => car.Id == id).FirstOrDefaultAsync();
        //}

        //public async Task CreateAsync(Carz car)
        //{
        //    await _cars.InsertOneAsync(car);
        //}

        //public async Task UpdateAsync(string id, Car carIn)
        //{
        //    await _cars.ReplaceOneAsync(car => car.Id == id, carIn);
        //}

        //public async Task RemoveAsync(string id)
        //{
        //    await _cars.DeleteOneAsync(car => car.Id == id);
        //}

        //public async Task<List<Car>> SearchByMakeOrModelAsync(string searchKey)
        //{
        //    var filter = Builders<Cars>.Filter.Or(
        //        Builders<Car>.Filter.Regex("Make", new MongoDB.Bson.BsonRegularExpression(searchKey, "i")),
        //        Builders<Car>.Filter.Regex("Model", new MongoDB.Bson.BsonRegularExpression(searchKey, "i"))
        //    );

        //    return await _cars.Find(filter).ToListAsync();
        //}
    }
}
