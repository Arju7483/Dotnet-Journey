using Microsoft.AspNetCore.Mvc;
using WebApiDemo.DTOs;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        // Hardcoded Categories
        private static List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Furniture" },
        };
        // Hardcoded Products
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 100, CategoryId = 1 },
            new Product { Id = 2, Name = "Desktop", Price = 2000, CategoryId = 1 },
            new Product { Id = 3, Name = "Chair", Price = 150, CategoryId = 2 },
        };
        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            var productDTOs = _products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryName = _categories.FirstOrDefault(c => c.Id == p.CategoryId)?.Name ?? "Unknown"
            }).ToList();
            return Ok(productDTOs);
        }
        // GET: api/products/{id}
        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProducts(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if(product == null)
            {
                return NotFound();

            }
            ProductDTO result = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryName = _categories.FirstOrDefault(c => c.Id == id)?.Name ?? "Unknown"
            };
            return Ok(result);
            
        }


    }
}
