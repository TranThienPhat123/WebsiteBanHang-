using System.ComponentModel.DataAnnotations;

namespace TranThienPhat_2280602326.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
