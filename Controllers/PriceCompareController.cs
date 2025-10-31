using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodPriceComparison.Data; 
using FoodPriceComparison.Services;
using System.Threading.Tasks;
using System.Linq;

namespace FoodPriceComparison.Controllers
{
    public class PriceCompareController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly FoodScraperService _scraper;

        public PriceCompareController(ApplicationDbContext context, FoodScraperService scraper)
        {
            _context = context;
            _scraper = scraper;
        }

        [HttpPost]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                ViewBag.Error = "Please enter a food item to search.";
                return View("Index");
            }

            // 🔥 Scrape online
            var scrapedResults = await _scraper.ScrapePricesAsync(query);

            // Fallback to DB if scraping fails
            if (!scrapedResults.Any())
            {
                scrapedResults = await _context.PlatformPrices
                    .Where(p => p.DishName.Contains(query))
                    .OrderBy(p => p.Price)
                    .ToListAsync();
            }

            if (!scrapedResults.Any())
            {
                ViewBag.Error = $"No results found for '{query}'.";
                return View("Index");
            }

            return View("Results", scrapedResults);
        }
    }
}
