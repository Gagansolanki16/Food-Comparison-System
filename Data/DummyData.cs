using FoodPriceComparison.Models;
using System.Collections.Generic;

namespace FoodPriceComparison.Data
{
    public static class DummyData
    {
        public static List<FoodItem> GetDummyPrices()
        {
            return new List<FoodItem>
            {
                // Vadodara Restaurants - Pizzas
                new FoodItem { Name = "Margherita Pizza", Price = 199m, Restaurant = "Domino's", DeliverySite = "Swiggy", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.swiggy.com/city/vadodara/dominos-pizza-abbas-tayabji-marg-fatehgunj-rest78360" }, 
                new FoodItem { Name = "Margherita Pizza", Price = 220m, Restaurant = "Domino's", DeliverySite = "Zomato", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.zomato.com/vadodara/dominos-pizza-1-fatehgunj/order" }, 
                new FoodItem { Name = "Pepperoni Pizza", Price = 299m, Restaurant = "Pizza Hut", DeliverySite = "Swiggy", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.swiggy.com/city/vadodara/pizza-hut-crossway-mall-mandvi-rest568731" }, 
                new FoodItem { Name = "Pepperoni Pizza", Price = 310m, Restaurant = "Pizza Hut", DeliverySite = "Zomato", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.zomato.com/vadodara/pizza-hut-manjalpur/order" }, 
                new FoodItem { Name = "Veggie Supreme Pizza", Price = 349m, Restaurant = "Papa Louie's", DeliverySite = "Swiggy", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.swiggy.com/city/vadodara/papa-louies-pizza-bricklane-complex-fatehgunj-rest618544" }, 
                new FoodItem { Name = "Veggie Supreme Pizza", Price = 360m, Restaurant = "Papa Louie's", DeliverySite = "Zomato", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.zomato.com/vadodara/papa-louies-pizza-fatehgunj/order" }, 

                // Vadodara Restaurants - Burgers
                new FoodItem { Name = "Burger", Price = 149m, Restaurant = "McDonald's", DeliverySite = "Swiggy", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.swiggy.com/city/vadodara/mcdonalds-seven-seas-mall-fatehgunj-rest68031" }, 
                new FoodItem { Name = "Burger", Price = 160m, Restaurant = "McDonald's", DeliverySite = "Zomato", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.zomato.com/vadodara/mcdonalds-alkapuri/order" }, 
                new FoodItem { Name = "Cheese Burger", Price = 199m, Restaurant = "Burger King", DeliverySite = "Swiggy", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.swiggy.com/city/vadodara/burger-king-iscon-jan-mahal-sayajigunj-rest573379" }, 
                new FoodItem { Name = "Cheese Burger", Price = 210m, Restaurant = "Burger King", DeliverySite = "Zomato", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.zomato.com/vadodara/burger-king-sayajigunj/order" }, 
                new FoodItem { Name = "Chicken Burger", Price = 229m, Restaurant = "Subway", DeliverySite = "Swiggy", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.swiggy.com/city/vadodara/subway-payal-complex-rest89813" }, 
                new FoodItem { Name = "Chicken Burger", Price = 240m, Restaurant = "Subway", DeliverySite = "Zomato", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.zomato.com/vadodara/subway-sayajigunj/order" }, 

                // Vadodara Restaurants - Local Dishes
                new FoodItem { Name = "Pav Bhaji", Price = 120m, Restaurant = "Honest", DeliverySite = "Swiggy", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.swiggy.com/city/vadodara/honest-vadiwadi-rest384077" }, 
                new FoodItem { Name = "Pav Bhaji", Price = 130m, Restaurant = "Honest", DeliverySite = "Zomato", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.zomato.com/vadodara/honest-vadiwadi/order" }, 
                new FoodItem { Name = "Biryani", Price = 250m, Restaurant = "Barbeque Nation", DeliverySite = "Swiggy", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.swiggy.com/city/vadodara/barbeque-nation-gotri-rest300373" }, 
                new FoodItem { Name = "Biryani", Price = 260m, Restaurant = "Barbeque Nation", DeliverySite = "Zomato", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.zomato.com/vadodara/barbeque-nation-vadiwadi/order" }, 
                new FoodItem { Name = "Dhokla", Price = 80m, Restaurant = "Radhe Dhokla", DeliverySite = "Swiggy", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.swiggy.com/city/vadodara/radhe-dhokla-punjabi-chinese-thali-and-biryani-akota-rest989603" }, 
                new FoodItem { Name = "Dhokla", Price = 90m, Restaurant = "Radhe Dhokla", DeliverySite = "Zomato", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.zomato.com/vadodara/radhe-dhokla-akota/order" }, 
                new FoodItem { Name = "Khakra", Price = 50m, Restaurant = "Jagdish Farsan", DeliverySite = "Swiggy", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.swiggy.com/city/vadodara/jagdish-farsan-and-sweets-iscon-jan-mahal-sayajigunj-rest358654" }, 
                new FoodItem { Name = "Khakra", Price = 55m, Restaurant = "Jagdish Farsan", DeliverySite = "Zomato", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.zomato.com/vadodara/jagdish-farshan-sayajigunj/order" }, 

              
                new FoodItem { Name = "Ice Cream", Price = 100m, Restaurant = "Baskin Robbins", DeliverySite = "Swiggy", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.swiggy.com/city/vadodara/baskin-robbins-ice-cream-desserts-alkapuri-rest67165" }, 
                new FoodItem { Name = "Ice Cream", Price = 110m, Restaurant = "Baskin Robbins", DeliverySite = "Zomato", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.zomato.com/vadodara/baskin-robbins-ice-cream-desserts-alkapuri/order" }, 
                new FoodItem { Name = "Manchurian", Price = 150m, Restaurant = "Goodies Cafe", DeliverySite = "Swiggy", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.swiggy.com/city/vadodara/goodies-cafe-sayajigunj-sayajiganj-rest73905" }, 
                new FoodItem { Name = "Manchurian", Price = 160m, Restaurant = "Goodies Cafe", DeliverySite = "Zomato", LastUpdated = DateTime.Now, RestaurantUrl = "https://www.zomato.com/vadodara/goodies-cafeteria-sayajigunj/order" }, 

            };
        }

        public static List<string> GetDummyRestaurants()
        {
            return GetDummyPrices().Select(p => p.Restaurant).Distinct().OrderBy(r => r).ToList();
        }
    }
}