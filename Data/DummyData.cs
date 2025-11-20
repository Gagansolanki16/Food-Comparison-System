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
                new FoodItem { Name = "Margherita Pizza", Price = 199m, Restaurant = "Domino's", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Margherita Pizza", Price = 220m, Restaurant = "Domino's", DeliverySite = "Zomato", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Pepperoni Pizza", Price = 299m, Restaurant = "Pizza Hut", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Pepperoni Pizza", Price = 310m, Restaurant = "Pizza Hut", DeliverySite = "Zomato", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Veggie Supreme Pizza", Price = 349m, Restaurant = "Papa John's", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Veggie Supreme Pizza", Price = 360m, Restaurant = "Papa John's", DeliverySite = "Zomato", LastUpdated = DateTime.Now },

                // Vadodara Restaurants - Burgers
                new FoodItem { Name = "Burger", Price = 149m, Restaurant = "McDonald's", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Burger", Price = 160m, Restaurant = "McDonald's", DeliverySite = "Zomato", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Cheese Burger", Price = 199m, Restaurant = "Burger King", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Cheese Burger", Price = 210m, Restaurant = "Burger King", DeliverySite = "Zomato", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Chicken Burger", Price = 229m, Restaurant = "Subway", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Chicken Burger", Price = 240m, Restaurant = "Subway", DeliverySite = "Zomato", LastUpdated = DateTime.Now },

                // Vadodara Restaurants - Local Dishes
                new FoodItem { Name = "Pav Bhaji", Price = 120m, Restaurant = "Honest", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Pav Bhaji", Price = 130m, Restaurant = "Honest", DeliverySite = "Zomato", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Biryani", Price = 250m, Restaurant = "Barbeque Nation", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Biryani", Price = 260m, Restaurant = "Barbeque Nation", DeliverySite = "Zomato", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Dhokla", Price = 80m, Restaurant = "Jayhind Sweets", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Dhokla", Price = 90m, Restaurant = "Jayhind Sweets", DeliverySite = "Zomato", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Khakra", Price = 50m, Restaurant = "Haldiram's", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Khakra", Price = 55m, Restaurant = "Haldiram's", DeliverySite = "Zomato", LastUpdated = DateTime.Now },

                // Vadodara Restaurants - Desserts
                new FoodItem { Name = "Ice Cream", Price = 100m, Restaurant = "Baskin Robbins", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Ice Cream", Price = 110m, Restaurant = "Baskin Robbins", DeliverySite = "Zomato", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Ras Malai", Price = 150m, Restaurant = "Sweet India", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
                new FoodItem { Name = "Ras Malai", Price = 160m, Restaurant = "Sweet India", DeliverySite = "Zomato", LastUpdated = DateTime.Now },

              
            };
        }

        public static List<string> GetDummyRestaurants()
        {
            return GetDummyPrices().Select(p => p.Restaurant).Distinct().OrderBy(r => r).ToList();
        }
    }
}