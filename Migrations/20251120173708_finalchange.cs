using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodPriceComparison.Migrations
{
    /// <inheritdoc />
    public partial class finalchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RestaurantUrl",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantUrl",
                table: "FoodItems");
        }
    }
}
