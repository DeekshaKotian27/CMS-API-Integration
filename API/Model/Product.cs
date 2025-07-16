using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int Quantity { get; set; }
    }
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int Quantity { get; set; }
    }

}
