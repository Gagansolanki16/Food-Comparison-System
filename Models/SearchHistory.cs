using System.ComponentModel.DataAnnotations;

namespace FoodPriceComparison.Models
{
    public class SearchHistory
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string SearchTerm { get; set; }
        public string? SelectedRestaurant { get; set; } // Explicit nullable
        public DateTime SearchedAt { get; set; } = DateTime.Now;
    }
}