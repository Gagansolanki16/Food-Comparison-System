using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodPriceComparison.Models
{
    public class FoodItem
    {
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [Required]
        [JsonPropertyName("restaurant")]
        public string Restaurant { get; set; }

        [Required]
        [JsonPropertyName("deliverySite")]
        public string DeliverySite { get; set; }

        [JsonPropertyName("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        public string RestaurantUrl { get; set; }
    }
}