using FoodPriceComparison.Models;

namespace FoodPriceComparison.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Removed: if (context.FoodItems.Any()) return;
            // Removed: All seeding code
            // DB will be empty on startup
        }
    }
}