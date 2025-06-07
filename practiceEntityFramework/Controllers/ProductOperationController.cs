using Microsoft.AspNetCore.Mvc;
using practiceEntityFramework.Interface;
using practiceEntityFramework.Entities.Products;

namespace practiceEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOperationController : Controller
    {
        private readonly IProductOperation _productOperation;
        public ProductOperationController(IProductOperation productOperation)
        {
            _productOperation = productOperation;
        }
        [HttpPut]
        public async Task<IActionResult> PutProducts([FromBody] List<Product> products)
        {
            if (products == null || products.Count == 0)
            {
                return BadRequest("Customer list is empty.");
            }

            await _productOperation.PutProduct(products);
            return NoContent();
        }
    }
}
