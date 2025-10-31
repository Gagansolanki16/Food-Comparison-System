using System.Collections.Generic;
using System.Threading.Tasks;
using FoodPriceComparison.Models;
using Microsoft.Playwright;

namespace FoodPriceComparison.Services
{
    public class FoodScraperService
    {
        public async Task<List<PlatformPrice>> ScrapePricesAsync(string query)
        {
            var results = new List<PlatformPrice>();

            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true // change to false if you want to see the browser
            });

            var page = await browser.NewPageAsync();

            // --- Swiggy Example ---
            await page.GotoAsync($"https://www.swiggy.com/search?q={query}", new PageGotoOptions
            {
                WaitUntil = WaitUntilState.NetworkIdle
            });

            // Wait for results to load (adjust selector)
            await page.WaitForSelectorAsync(".styles_itemName__hLfgz");

            var swiggyItems = await page.QuerySelectorAllAsync(".styles_itemName__hLfgz");
            foreach (var item in swiggyItems)
            {
                var name = await item.InnerTextAsync();
                var priceElement = await item.QuerySelectorAsync(".. .rupee");
                var priceText = priceElement != null ? await priceElement.InnerTextAsync() : "0";

                if (decimal.TryParse(priceText.Replace("₹", "").Trim(), out var price))
                {
                    results.Add(new PlatformPrice
                    {
                        DishName = name,
                        PlatformName = "Swiggy",
                        Price = price
                    });
                }
            }

            // --- Zomato Example ---
            await page.GotoAsync($"https://www.zomato.com/ncr/restaurants?search={query}", new PageGotoOptions
            {
                WaitUntil = WaitUntilState.NetworkIdle
            });

            // Adjust selector based on actual Zomato DOM
            var zomatoItems = await page.QuerySelectorAllAsync(".sc-1s0saks-17");
            foreach (var item in zomatoItems)
            {
                var name = await item.InnerTextAsync();
                var priceElement = await item.QuerySelectorAsync(".. .sc-17hyc2s-1");
                var priceText = priceElement != null ? await priceElement.InnerTextAsync() : "0";

                if (decimal.TryParse(priceText.Replace("₹", "").Trim(), out var price))
                {
                    results.Add(new PlatformPrice
                    {
                        DishName = name,
                        PlatformName = "Zomato",
                        Price = price
                    });
                }
            }

            return results;
        }
    }
}
