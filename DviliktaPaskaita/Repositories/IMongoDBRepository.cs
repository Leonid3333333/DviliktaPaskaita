using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using YourNamespace.Models;
using MongoDB.Driver;

namespace DviliktaPaskaita.Repositories
{
    public interface IMongoDBRepository
    {

        Task<IEnumerable<Cars>> GetAllCarsAsync();
        Task AddAllCarsAsync(IEnumerable<Cars> cars);
        Task<List<Cars>> SearchByMakeOrModelAsync(string searchKey);
        Task<List<Customer>> GetAllAsync();
        Task<List<Customer>> SearchAsync(string searchKey);
        Task AddAllCustomersAsync(IEnumerable<Customer> customers);

        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        //  Task<Customer> GetByIdAsync(string id);

        //Task AddAllCarAsync(object result);


        // Task<Cars> GetByIdAsync();
        //Task<Cars> GetByIdAsync(string id);
        //    Task CreateAsync(Category category);
        //    Task UpdateAsync(Category category);
        //    Task DeleteAsync(ObjectId id);
    }
}