﻿using System.Collections.Generic;
using System.Threading.Tasks;
using YourNamespace.Models;

namespace YourNamespace.Repositories
{
    public interface IRentalRepository
    {
        Task<IEnumerable<Rental>> GetAllRentalsAsync();
        Task<Rental> GetRentalByIdAsync(int id);
        Task AddRentalAsync(Rental rental);
        Task UpdateRentalAsync(Rental rental);
        Task DeleteRentalAsync(int id);
        Task<bool> IsCarAvailableAsync(int carId, DateTime fromDate, DateTime toDate);
        Task<bool> IsCarAvailableAsync();
    }
}