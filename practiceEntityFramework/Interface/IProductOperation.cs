using practiceEntityFramework.Entities.Products;

namespace practiceEntityFramework.Interface
{
    public interface IProductOperation
    {
        Task PutProduct(List<Product> products);  
    }
}
