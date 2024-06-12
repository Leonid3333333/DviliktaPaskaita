// CustomerRepository.cs
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using YourNamespace.Models;
using System.Data.SqlClient;

namespace YourNamespace.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private const string Sql = "SELECT * FROM Customers WHERE Id = @Id";
        private readonly string _connectionString;

        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            using var db = Connection;
            return await db.QueryAsync<Customer>("SELECT * FROM Customers");
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            using var db = Connection;
            return await db.QueryFirstOrDefaultAsync<Customer>("SELECT * FROM Customers WHERE Id = @Id", new { Id = id });
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            using var db = Connection;
            var sql = @"INSERT INTO Customers (Name, Email, PhoneNumber) 
                            VALUES (@Name, @Email, @PhoneNumber)";
            await db.ExecuteAsync(sql, customer);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            using var db = Connection;
            var sql = @"UPDATE Customers 
                            SET Name = @Name, Email = @Email, PhoneNumber = @PhoneNumber 
                            WHERE Id = @Id";
            await db.ExecuteAsync(sql, customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            using var db = Connection;
            var sql = @"DELETE FROM Customers WHERE Id = @Id";
            await db.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<Customer> GetCustomerByIdAsync(object customer, object id)
        {
            using var db = Connection;
            return await db.QueryFirstOrDefaultAsync<Customer>(Sql, new { Id = id });
        }

        public Task<Customer> UpdateCustomerAsync()
        {
            throw new NotImplementedException();
        }
    }
}
