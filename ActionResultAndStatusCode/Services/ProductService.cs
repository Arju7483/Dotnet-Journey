using ActionResultAndStatusCode.Entities;

namespace ActionResultAndStatusCode.Services
{
    public class ProductService
    {
        List<Product> products = new List<Product>()
        {
            new Product(){Id = 1, Name = "Mobile", Price = 100},
            new Product(){Id = 3, Name = "Laptop", Price = 200},
            new Product(){Id = 4, Name = "Mouse", Price = 200},
            new Product(){Id = 5, Name = "Keyboard", Price = 200},
        };
        public async Task<List<Product>> getAll()
        {
            return products; 
        }
        public async Task<Product> getById(int id)
        {
            Product product = products.Find(p => p.Id == id);
            return product;
        }
        public async Task<int> CreateProduct(CreateProductDTO product)
        {
            int id = products.Count() + 1;
            Product newProduct = new Product()
            {
                Id = id,
                Name = product.Name,
                Price = product.Price,
            };
            products.Add(newProduct);
            return id;
        }
    }
}
