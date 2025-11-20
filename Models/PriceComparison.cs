using System.Collections.Generic;

namespace FoodPriceComparison.Models
{
    public class PriceComparison
    {
        public string FoodName { get; set; }
        public List<FoodItem> Items { get; set; } = new List<FoodItem>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Favorite> Favorites { get; set; } = new List<Favorite>(); 
        public decimal LowestPrice => Items.Any() ? Items.Min(i => i.Price) : 0;
        public string BestSite => Items.Any() ? Items.OrderBy(i => i.Price).First().DeliverySite : "";
    }
}