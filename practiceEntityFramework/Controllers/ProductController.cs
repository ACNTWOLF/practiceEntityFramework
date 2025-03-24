using Microsoft.AspNetCore.Mvc;
using AdventureWorksAPI.Models;
using practiceEntityFramework.Interface;

namespace AdventureWorksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            var createdProduct = await _repository.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.ProductID }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return BadRequest("El ID del producto no coincide con el ID enviado.");
            }

            var result = await _repository.UpdateProductAsync(product);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _repository.DeleteProductByIdAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
