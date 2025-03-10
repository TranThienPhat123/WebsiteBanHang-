using System.Collections.Generic;

using TranThienPhat_2280602326.Models;
namespace TranThienPhat_2280602326.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
