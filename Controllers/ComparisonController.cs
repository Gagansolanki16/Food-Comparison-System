using FoodPriceComparison.Data;
using FoodPriceComparison.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodPriceComparison.Controllers
{
    [Authorize]
    public class ComparisonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComparisonController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string foodItem, string selectedRestaurant)
        {
            // Get unique restaurant names for dropdown (from Vadodara data)
            var restaurants = await _context.FoodItems
                .Select(f => f.Restaurant)
                .Distinct()
                .OrderBy(r => r)
                .ToListAsync();

            ViewBag.Restaurants = restaurants;

            if (!string.IsNullOrEmpty(foodItem))
            {
                var query = _context.FoodItems.Where(f => f.Name.Contains(foodItem));

                // Filter by selected restaurant if provided
                if (!string.IsNullOrEmpty(selectedRestaurant))
                {
                    query = query.Where(f => f.Restaurant == selectedRestaurant);
                }

                var items = await query.ToListAsync();

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