using FoodPriceComparison.Data;
using FoodPriceComparison.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;

        public ComparisonController(ApplicationDbContext context, IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            _context = context;
            var port = configuration["ASPNETCORE_HTTPS_PORT"] ?? "5001";
            _httpClient = new HttpClient { BaseAddress = new Uri($"https://localhost:{port}") };
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string foodItem, string selectedRestaurant)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;
            var favorites = userId != null ? await _context.Favorites.Where(f => f.UserId == userId).ToListAsync() : new List<Favorite>();

            // Fetch restaurants
            var restaurantResponse = await _httpClient.GetAsync("api/priceapi/restaurants");
            var restaurants = new List<string>();
            if (restaurantResponse.IsSuccessStatusCode)
            {
                restaurants = await JsonSerializer.DeserializeAsync<List<string>>(await restaurantResponse.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            ViewBag.Restaurants = restaurants ?? new List<string>();

            if (!string.IsNullOrEmpty(foodItem))
            {
                // Track search history
                if (userId != null)
                {
                    var history = new SearchHistory
                    {
                        UserId = userId,
                        SearchTerm = foodItem,
                        SelectedRestaurant = selectedRestaurant
                    };
                    _context.SearchHistories.Add(history);
                    await _context.SaveChangesAsync();
                }

                // Fetch prices
                var apiResponse = await _httpClient.GetAsync($"api/priceapi/fetch/{foodItem}");
                var apiItems = new List<FoodItem>();
                if (apiResponse.IsSuccessStatusCode)
                {
                    apiItems = await JsonSerializer.DeserializeAsync<List<FoodItem>>(await apiResponse.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }

                // Save to DB
                foreach (var item in apiItems)
                {
                    if (string.IsNullOrWhiteSpace(item?.Name) || string.IsNullOrWhiteSpace(item?.Restaurant) || string.IsNullOrWhiteSpace(item?.DeliverySite))
                        continue;
                    if (item?.Price <= 0) continue;

                    var existing = await _context.FoodItems.FirstOrDefaultAsync(f => f.Name == item.Name && f.Restaurant == item.Restaurant && f.DeliverySite == item.DeliverySite);
                    if (existing != null)
                    {
                        existing.Price = item.Price;
                        existing.LastUpdated = item.LastUpdated;
                    }
                    else
                    {
                        _context.FoodItems.Add(item);
                    }
                }
                await _context.SaveChangesAsync();

                // Query DB
                var query = _context.FoodItems.Where(f => f.Name.Contains(foodItem));
                if (!string.IsNullOrEmpty(selectedRestaurant))
                {
                    query = query.Where(f => f.Restaurant == selectedRestaurant);
                }
                var items = await query.ToListAsync();

                // Fetch reviews for restaurants in results
                var restaurantNames = items.Select(i => i.Restaurant).Distinct().ToList();
                var reviews = await _context.Reviews.Where(r => restaurantNames.Contains(r.Restaurant)).ToListAsync();

                var comparison = new PriceComparison
                {
                    FoodName = foodItem,
                    Items = items,
                    Reviews = reviews,
                    Favorites = favorites
                };

                return View(comparison);
            }

            return View(new PriceComparison());
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(string restaurant, string reviewText, int rating)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var review = new Review
            {
                UserId = user.Id,
                Restaurant = restaurant,
                ReviewText = reviewText,
                Rating = rating
            };
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite(string itemName, string restaurant)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();
            var existing = await _context.Favorites.FirstOrDefaultAsync(f => f.UserId == user.Id && f.ItemName == itemName && f.Restaurant == restaurant);
            if (existing == null)
            {
                var favorite = new Favorite
                {
                    UserId = user.Id,
                    ItemName = itemName,
                    Restaurant = restaurant
                };
                _context.Favorites.Add(favorite);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Favorites()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var favorites = await _context.Favorites.Where(f => f.UserId == user.Id).ToListAsync();
            return View(favorites);
        }

        public async Task<IActionResult> SearchHistory()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var history = await _context.SearchHistories.Where(h => h.UserId == user.Id).OrderByDescending(h => h.SearchedAt).ToListAsync();
            return View(history);
        }
    }
}