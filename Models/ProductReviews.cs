using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace eCommerce_BiliBits.Models
{
    public class ProductReviews
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        public string? UserId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [StringLength(1000)]
        public string? Comment { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual Product? Product { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser? User { get; set; }
    }
}
