using FoodPriceComparison.Data;
using FoodPriceComparison.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FoodPriceComparison.Controllers
{
    [Authorize]
    public class ComparisonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ComparisonController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            var port = configuration["ASPNETCORE_HTTPS_PORT"] ?? "5001";
            _httpClient = new HttpClient { BaseAddress = new Uri($"https://localhost:{port}") };
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IActionResult> Index(string foodItem, string selectedRestaurant)
        {
            // Fetch restaurants from API
            var restaurantResponse = await _httpClient.GetAsync("api/priceapi/restaurants");
            var restaurants = new List<string>();
            if (restaurantResponse.IsSuccessStatusCode)
            {
                restaurants = await JsonSerializer.DeserializeAsync<List<string>>(await restaurantResponse.Content.ReadAsStreamAsync(), _jsonOptions);
                Console.WriteLine($"Fetched {restaurants.Count} restaurants from API");
            }
            ViewBag.Restaurants = restaurants ?? new List<string>();

            if (!string.IsNullOrEmpty(foodItem))
            {
                Console.WriteLine($"Searching for: {foodItem}");

                // Fetch prices from API
                var apiResponse = await _httpClient.GetAsync($"api/priceapi/fetch/{foodItem}");
                var apiItems = new List<FoodItem>();
                if (apiResponse.IsSuccessStatusCode)
                {
                    apiItems = await JsonSerializer.DeserializeAsync<List<FoodItem>>(await apiResponse.Content.ReadAsStreamAsync(), _jsonOptions);
                    Console.WriteLine($"Fetched {apiItems.Count} items from API for {foodItem}");
                }
                else
                {
                    Console.WriteLine($"API call failed for {foodItem}: {apiResponse.StatusCode}");
                }

                // Save to DB
                int savedCount = 0;
                foreach (var item in apiItems)
                {
                    Console.WriteLine($"Processing item: Name='{item?.Name}', Restaurant='{item?.Restaurant}', DeliverySite='{item?.DeliverySite}', Price={item?.Price}");

                    if (string.IsNullOrWhiteSpace(item?.Name) || string.IsNullOrWhiteSpace(item?.Restaurant) || string.IsNullOrWhiteSpace(item?.DeliverySite))
                    {
                        Console.WriteLine($"Skipping item due to null/empty fields");
                        continue;
                    }

                    if (item?.Price <= 0)
                    {
                        Console.WriteLine($"Skipping item due to invalid price: {item?.Price}");
                        continue;
                    }

                    var existing = await _context.FoodItems.FirstOrDefaultAsync(f => f.Name == item.Name && f.Restaurant == item.Restaurant && f.DeliverySite == item.DeliverySite);
                    if (existing != null)
                    {
                        existing.Price = item.Price;
                        existing.LastUpdated = item.LastUpdated;
                        Console.WriteLine($"Updated {item.Name}");
                    }
                    else
                    {
                        _context.FoodItems.Add(item);
                        Console.WriteLine($"Added {item.Name}");
                    }
                    savedCount++;
                }
                await _context.SaveChangesAsync();
                Console.WriteLine($"Saved {savedCount} items to DB");

                // Query DB for display
                var query = _context.FoodItems.Where(f => f.Name.Contains(foodItem));
                if (!string.IsNullOrEmpty(selectedRestaurant))
                {
                    query = query.Where(f => f.Restaurant == selectedRestaurant);
                }
                var items = await query.ToListAsync();
                Console.WriteLine($"Found {items.Count} items in DB for {foodItem}");

                var comparison = new PriceComparison
                {
                    FoodName = foodItem,
                    Items = items
                };

                return View(comparison);
            }

            return View(new PriceComparison());
        }
    }
}