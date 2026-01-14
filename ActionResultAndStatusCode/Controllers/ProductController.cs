using ActionResultAndStatusCode.Entities;
using Microsoft.AspNetCore.Mvc;
using ActionResultAndStatusCode.Services;
using System.Threading.Tasks;
namespace ActionResultAndStatusCode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService) {
            _productService = productService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            List<Product> products = await _productService.getAll();
            return StatusCode(208,products);
        }
        [HttpGet("Id/{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            Product p = await _productService.getById(id);
            if(p == null)
            {
               return NotFound();
            }
            return Ok(p);
        }
        [HttpPost("Create")]
        public async Task<ActionResult> CreateProduct(CreateProductDTO product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            int id = await _productService.CreateProduct(product);
            var customResponse = new
            {
                StatusCode = 202,
                Id = id,
                Message = $"New Product Created with Id {id}"
            };
            return StatusCode(200,customResponse);
        }

    }
}
