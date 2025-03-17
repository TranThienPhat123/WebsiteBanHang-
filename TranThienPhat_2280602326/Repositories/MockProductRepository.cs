using System.Collections.Generic;
using System.Linq;
using TranThienPhat_2280602326.Models;
namespace TranThienPhat_2280602326.Repositories
{
    public class MockProductRepository : IProductRepository
    {
        private readonly List<Product> _products;
        public MockProductRepository()
        {
            // Tạo một số dữ liệu mẫu
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 5000, Description = "A high-end laptop" },
                new Product { Id = 2, Name = "Laptop", Price = 6000, Description = "A medium-end laptop" },
                new Product { Id = 3, Name = "Laptop", Price = 3000, Description = "A low-end laptop" },
            };
        }
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }
        public void Update(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index != -1)
            {
                _products[index] = product;
            }
        }
        public void Delete(int id)  
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
