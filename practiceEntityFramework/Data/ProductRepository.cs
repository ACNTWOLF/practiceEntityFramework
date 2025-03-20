using practiceEntityFramework.Interface;
using Microsoft.EntityFrameworkCore;
using AdventureWorksAPI.Data;
using AdventureWorksAPI.Models;
using System;
namespace practiceEntityFramework.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdventureWorksContext _context;
        public ProductRepository(AdventureWorksContext context) 
        {
            _context = context;
            
            
        }
        //public async Task<Product> GetProductsAsync()=> await
        public async Task<Product> GetCustomerByIdAsync(int id)
           => await _context.Products.FindAsync(id);

        public async Task<IEnumerable<Product>> GetCustomersAsync()
            => await _context.Products.Take(100).ToListAsync();

        public async Task<Product> CreateCustomerAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public interface ICustomerRepository
        {
        }
    }
}
