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
        public async Task<Product> GetProductAsync(int id)
            => await _context.Product.FindAsync(id);

        public async Task<IEnumerable<Product>> GetProductAsync()
            => await _context.Product.Take(100).ToListAsync();

        public async Task<Product> GetProductAsync(Product person)
        {
            _context.Product.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }
    }
}
