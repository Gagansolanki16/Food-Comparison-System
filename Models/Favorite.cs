using System.ComponentModel.DataAnnotations;

namespace FoodPriceComparison.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; } // FK to IdentityUser
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string Restaurant { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.Now;
    }
}