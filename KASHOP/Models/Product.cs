using System.ComponentModel.DataAnnotations;

namespace KASHOP.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0,10000)]
        public decimal Price { get; set; }
        public double Rate { get; set; }
        public string? Image {  get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
