using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Range(1,10000)]
        public int Price { get; set; }
        public int CategoryId { get; set; }
    }
}
