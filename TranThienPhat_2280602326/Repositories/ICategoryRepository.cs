using TranThienPhat_2280602326.Models;

namespace TranThienPhat_2280602326.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
}
