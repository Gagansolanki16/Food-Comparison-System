using System.ComponentModel.DataAnnotations;

namespace FoodPriceComparison.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; } // FK to IdentityUser
        [Required]
        public string Restaurant { get; set; }
        [Required]
        public string ReviewText { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; } // 1-5 stars
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}