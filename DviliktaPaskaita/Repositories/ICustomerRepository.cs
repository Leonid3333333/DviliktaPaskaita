using System.Collections.Generic;
using System.Threading.Tasks;
using YourNamespace.Models;

namespace YourNamespace.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
        Task<Customer> GetCustomerByIdAsync(object customer, object id);
        Task<Customer> UpdateCustomerAsync();
    }
}