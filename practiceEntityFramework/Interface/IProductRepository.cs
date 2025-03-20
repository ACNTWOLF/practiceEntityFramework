using System;
using AdventureWorksAPI.Models;

namespace practiceEntityFramework.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetCustomersAsync();
    }
}
