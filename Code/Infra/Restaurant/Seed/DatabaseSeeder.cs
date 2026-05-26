using Data.Restaurant.Entities;
using Data.Restaurant.Enums;
using Infra.Restaurant.Data;
using Microsoft.EntityFrameworkCore;

using RestaurantEntity = Data.Restaurant.Entities.Restaurant;

namespace Infra.Restaurant.Seed;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (await db.Restaurants.AnyAsync())
            return;

        var restaurant = new RestaurantEntity
        {
            Id = Guid.NewGuid(),
            Name = "Demo Restaurant",
            Address = "Main Street 1"
        };
    }
}