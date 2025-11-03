namespace FoodPriceComparison.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Restaurant { get; set; }
        public string DeliverySite { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}