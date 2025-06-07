using practiceEntityFramework.Interface;
using Microsoft.EntityFrameworkCore;
using AdventureWorksAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using practiceEntityFramework.Entities.Products;

namespace practiceEntityFramework.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdventureWorksContext _context;

        public ProductRepository(AdventureWorksContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
            => await _context.Product.FindAsync(id);

        public async Task<IEnumerable<Product>> GetProductsAsync()
            => await _context.Product.Take(100).ToListAsync();

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.ProductID))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductID == id);
        }
    }
}
