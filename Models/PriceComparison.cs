using System.Collections.Generic;

namespace FoodPriceComparison.Models
{
    public class PriceComparison
    {
        public string FoodName { get; set; }
        public List<FoodItem> Items { get; set; } = new List<FoodItem>();
        public decimal LowestPrice => Items.Min(i => i.Price);
        public string BestSite => Items.OrderBy(i => i.Price).First().DeliverySite;
    }
}