using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranThienPhat_2280602326.Models;
using TranThienPhat_2280602326.Repositories;

namespace WebBanHang.Repositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        private readonly List<Category> _categoryList;

        public MockCategoryRepository()
        {
            // Tạo một số dữ liệu mẫu
            _categoryList = new List<Category>
            {
                new Category { Id = 1, Name = "Laptop" },
                new Category { Id = 2, Name = "Desktop" },
                // Thêm các category khác
            };
        }

        // Triển khai phương thức bất đồng bộ
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            // Trả về dữ liệu giả lập một cách bất đồng bộ
            return await Task.FromResult(_categoryList);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            // Trả về category giả lập một cách bất đồng bộ
            return await Task.FromResult(_categoryList.FirstOrDefault(c => c.Id == id));
        }

        public async Task AddAsync(Category category)
        {
            // Thêm category vào danh sách giả lập một cách bất đồng bộ
            category.Id = _categoryList.Max(c => c.Id) + 1;
            _categoryList.Add(category);
            await Task.CompletedTask; // Đánh dấu hoàn thành tác vụ
        }

        public async Task UpdateAsync(Category category)
        {
            // Cập nhật category trong danh sách giả lập một cách bất đồng bộ
            var index = _categoryList.FindIndex(c => c.Id == category.Id);
            if (index != -1)
            {
                _categoryList[index] = category;
            }
            await Task.CompletedTask; // Đánh dấu hoàn thành tác vụ
        }

        public async Task DeleteAsync(int id)
        {
            // Xóa category khỏi danh sách giả lập một cách bất đồng bộ
            var category = _categoryList.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _categoryList.Remove(category);
            }
            await Task.CompletedTask; // Đánh dấu hoàn thành tác vụ
        }
    }
}
