using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_BiliBits.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        
        public decimal Price { get; set; }
        
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Product image is required")]
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        
        public virtual ICollection<ProductReviews>? Reviews { get; set; }
    }
}
