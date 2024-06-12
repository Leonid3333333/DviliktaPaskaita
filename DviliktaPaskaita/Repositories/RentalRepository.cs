// RentalRepository.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using YourNamespace.Models;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace YourNamespace.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        public readonly string _connectionString;

        public RentalRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
        {
            using var db = Connection;
            return await db.QueryAsync<Rental>("SELECT * FROM Rentals");
        }

        public async Task<Rental> GetRentalByIdAsync(int id)
        {
            using var db = Connection;
            return await db.QueryFirstOrDefaultAsync<Rental>("SELECT * FROM Rentals WHERE Id = @Id", new { Id = id });
        }


        public async Task AddRentalAsync(Rental rental)
        {
            using var db = Connection;
            var sql = @"INSERT INTO Rentals (CarId, CustomerId, FromDate, ToDate) 
                            VALUES (@CarId, @CustomerId, @FromDate, @ToDate)";
            await db.ExecuteAsync(sql, rental);
        }

        public async Task UpdateRentalAsync(Rental rental)
        {
            using var db = Connection;
            var sql = @"UPDATE Rentals SET CarId = @CarId, CustomerId = @CustomerId, FromDate = @FromDate, ToDate = @ToDate
                            WHERE Id = @Id";
            await db.ExecuteAsync(sql, rental);
        }

        public async Task DeleteRentalAsync(int id)
        {
            using var db = Connection;
            var sql = @"DELETE FROM Rentals WHERE Id = @Id";
            await db.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<bool> IsCarAvailableAsync(int carId, DateTime fromDate, DateTime toDate)
        {
            using var db = Connection;
            var sql = @"SELECT COUNT(1) FROM Rentals 
                            WHERE CarId = @CarId AND (
                                (@FromDate BETWEEN FromDate AND ToDate) OR 
                                (@ToDate BETWEEN FromDate AND ToDate) OR 
                                (FromDate BETWEEN @FromDate AND @ToDate) OR 
                                (ToDate BETWEEN @FromDate AND @ToDate)
                            )";
            var count = await db.ExecuteScalarAsync<int>(sql, new { CarId = carId, FromDate = fromDate, ToDate = toDate });
            return count == 0;
        }

        public Task<bool> IsCarAvailableAsync()
        {
            throw new NotImplementedException();
        }
    }
}
