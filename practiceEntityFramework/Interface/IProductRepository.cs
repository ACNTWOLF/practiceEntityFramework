using System.Collections.Generic;
using System.Threading.Tasks;
using practiceEntityFramework.Entities.Products;

namespace practiceEntityFramework.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductByIdAsync(int id);
    }
}
