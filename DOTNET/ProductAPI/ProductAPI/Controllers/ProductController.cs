using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Services;
using ProductAPI.DTO;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService pService;
        public ProductController(IProductService productService)
        {
            pService = productService;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var productss = pService.GetAllProducts();
            return Ok(productss);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = pService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = pService.DeleteProduct(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductCreateDTO productCreateDTO)
        {
            var updatedProduct = pService.UpdateProduct(id, productCreateDTO);
            if (updatedProduct == null)
            {
                return NotFound();
            }
            return Ok(updatedProduct);
        }
        [HttpPost]
        public IActionResult AddProduct(ProductCreateDTO productCreateDTO)
        {
            var newProduct = pService.AddProduct(productCreateDTO);
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.ProductId }, newProduct);

        }
    }
}
