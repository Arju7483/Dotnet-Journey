using System.ComponentModel.DataAnnotations;
using WebApiDemo.Models;

namespace WebApiDemo.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null;
        public int Price { get; set; }
        public string CategoryName { get; set; }

    }
    public class UpdateProductDTO
    {
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }
    }
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "Id is required")]
        public string Name { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
