using FoodPriceComparison.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FoodPriceComparison.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceApiController : ControllerBase
    {
        // Dummy data simulating Vadodara prices from Swiggy and Zomato
        private static readonly List<FoodItem> DummyPrices = new List<FoodItem>
        {
            // Pizza
            new FoodItem { Name = "Margherita Pizza", Price = 199m, Restaurant = "Domino's", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
            new FoodItem { Name = "Margherita Pizza", Price = 220m, Restaurant = "Domino's", DeliverySite = "Zomato", LastUpdated = DateTime.Now },
            new FoodItem { Name = "Pepperoni Pizza", Price = 299m, Restaurant = "Pizza Hut", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
            new FoodItem { Name = "Pepperoni Pizza", Price = 310m, Restaurant = "Pizza Hut", DeliverySite = "Zomato", LastUpdated = DateTime.Now },

            // Burger
            new FoodItem { Name = "Burger", Price = 149m, Restaurant = "McDonald's", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
            new FoodItem { Name = "Burger", Price = 160m, Restaurant = "McDonald's", DeliverySite = "Zomato", LastUpdated = DateTime.Now },
            new FoodItem { Name = "Cheese Burger", Price = 199m, Restaurant = "Burger King", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
            new FoodItem { Name = "Cheese Burger", Price = 210m, Restaurant = "Burger King", DeliverySite = "Zomato", LastUpdated = DateTime.Now },

            // More items
            new FoodItem { Name = "Biryani", Price = 250m, Restaurant = "Barbeque Nation", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
            new FoodItem { Name = "Biryani", Price = 260m, Restaurant = "Barbeque Nation", DeliverySite = "Zomato", LastUpdated = DateTime.Now },
            new FoodItem { Name = "Pav Bhaji", Price = 120m, Restaurant = "Honest", DeliverySite = "Swiggy", LastUpdated = DateTime.Now },
            new FoodItem { Name = "Pav Bhaji", Price = 130m, Restaurant = "Honest", DeliverySite = "Zomato", LastUpdated = DateTime.Now }
        };

        [HttpGet("fetch/{foodItem}")]
        public IActionResult FetchPrices(string foodItem)
        {
            // Simulate API delay
            Thread.Sleep(1000);

            // Filter dummy data by food item (case-insensitive)
            var results = DummyPrices.Where(p => p.Name.Contains(foodItem, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!results.Any())
            {
                return NotFound(new { Message = $"No prices found for {foodItem}" });
            }

            return Ok(results);
        }

        [HttpGet("restaurants")]
        public IActionResult GetRestaurants()
        {
            var restaurants = DummyPrices.Select(p => p.Restaurant).Distinct().OrderBy(r => r).ToList();
            return Ok(restaurants);
        }
    }
}