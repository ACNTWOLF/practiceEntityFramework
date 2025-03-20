using AdventureWorksAPI.Models;
using Microsoft.AspNetCore.Mvc;
using practiceEntityFramework.Interface;

namespace practiceEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var products = await _productRepository.GetProductAsync();
            return Ok(products);
        }
    }
}
