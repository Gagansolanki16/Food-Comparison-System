using FoodPriceComparison.Data;
using FoodPriceComparison.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FoodPriceComparison.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")] // If using JWT
    [ApiController]
    [Route("api/[controller]")]
    public class PriceApiController : ControllerBase
    {
        private static readonly List<FoodItem> DummyPrices = DummyData.GetDummyPrices();

        [HttpGet("fetch/{foodItem}")]
        public IActionResult FetchPrices(string foodItem)
        {
            Thread.Sleep(1000); // Simulate delay

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
            var restaurants = DummyData.GetDummyRestaurants();
            return Ok(restaurants);
        }
    }
}