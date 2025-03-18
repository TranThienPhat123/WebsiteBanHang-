using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranThienPhat_2280602326.Models;
using TranThienPhat_2280602326.Repositories;

public class MockProductRepository : IProductRepository
{
    private readonly List<Product> _products;

    public MockProductRepository()
    {
        // Tạo một số dữ liệu mẫu
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000, Description = "A high-end laptop" },
            // Thêm các sản phẩm khác
        };
    }

    // Triển khai phương thức bất đồng bộ
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        // Trả về dữ liệu giả lập một cách bất đồng bộ
        return await Task.FromResult(_products);
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        // Trả về sản phẩm giả lập một cách bất đồng bộ
        return await Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
    }

    public async Task AddAsync(Product product)
    {
        // Thêm sản phẩm vào danh sách giả lập một cách bất đồng bộ
        product.Id = _products.Max(p => p.Id) + 1;
        _products.Add(product);
        await Task.CompletedTask; // Đánh dấu hoàn thành tác vụ
    }

    public async Task UpdateAsync(Product product)
    {
        // Cập nhật sản phẩm trong danh sách giả lập một cách bất đồng bộ
        var index = _products.FindIndex(p => p.Id == product.Id);
        if (index != -1)
        {
            _products[index] = product;
        }
        await Task.CompletedTask; // Đánh dấu hoàn thành tác vụ
    }

    public async Task DeleteAsync(int id)
    {
        // Xóa sản phẩm khỏi danh sách giả lập một cách bất đồng bộ
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _products.Remove(product);
        }
        await Task.CompletedTask; // Đánh dấu hoàn thành tác vụ
    }
}
