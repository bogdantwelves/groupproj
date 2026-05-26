using Data.Restaurant.Entities;
using Data.Restaurant.Enums;
using Infra.Restaurant.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Restaurant.Seed;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (await db.Restaurants.AnyAsync())
            return;

        var restaurant = new Restaurant
        {
            Id = Guid.NewGuid(),
            Name = "Demo Restaurant",
            Address = "Main Street 1"
        };

        var tables = new List<RestaurantTable>
        {
            new()
            {
                Id = Guid.NewGuid(),
                TableNumber = 1,
                Capacity = 2,
                IsAvailable = true,
                Restaurant = restaurant
            },
            new()
            {
                Id = Guid.NewGuid(),
                TableNumber = 2,
                Capacity = 2,
                IsAvailable = true,
                Restaurant = restaurant
            },
            new()
            {
                Id = Guid.NewGuid(),
                TableNumber = 3,
                Capacity = 4,
                IsAvailable = true,
                Restaurant = restaurant
            },
            new()
            {
                Id = Guid.NewGuid(),
                TableNumber = 4,
                Capacity = 6,
                IsAvailable = true,
                Restaurant = restaurant
            },
            new()
            {
                Id = Guid.NewGuid(),
                TableNumber = 5,
                Capacity = 8,
                IsAvailable = true,
                Restaurant = restaurant
            }
        };

        var customers = new List<Customer>
        {
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "Alice Brown",
                Email = "alice@test.com",
                PhoneNumber = "111111"
            },
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "Bob Smith",
                Email = "bob@test.com",
                PhoneNumber = "222222"
            },
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "Charlie Green",
                Email = "charlie@test.com",
                PhoneNumber = "333333"
            }
        };

        var staff = new List<Staff>
        {
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "Admin User",
                Role = StaffRole.Admin,
                Restaurant = restaurant
            },
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "John Waiter",
                Role = StaffRole.Waiter,
                Restaurant = restaurant
            },
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "Maria Chef",
                Role = StaffRole.Chef,
                Restaurant = restaurant
            }
        };

        var menu = new Menu
        {
            Id = Guid.NewGuid(),
            Name = "Main Menu",
            Restaurant = restaurant
        };

        var menuItems = new List<MenuItem>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Caesar Salad",
                Description = "Fresh salad with chicken",
                Price = 7.50m,
                Menu = menu
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Tomato Soup",
                Description = "Classic tomato soup",
                Price = 5.00m,
                Menu = menu
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Burger",
                Description = "Beef burger with fries",
                Price = 11.90m,
                Menu = menu
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Pasta Carbonara",
                Description = "Pasta with creamy sauce",
                Price = 12.50m,
                Menu = menu
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Grilled Salmon",
                Description = "Salmon with vegetables",
                Price = 18.00m,
                Menu = menu
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Pizza Margherita",
                Description = "Pizza with tomato and cheese",
                Price = 10.00m,
                Menu = menu
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Cheesecake",
                Description = "Classic cheesecake",
                Price = 6.00m,
                Menu = menu
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Coffee",
                Description = "Black coffee",
                Price = 3.00m,
                Menu = menu
            }
        };

        var inventory = new Inventory
        {
            Id = Guid.NewGuid(),
            Restaurant = restaurant
        };

        var ingredients = new List<Ingredient>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Tomatoes",
                Quantity = 20,
                LowStockThreshold = 5,
                Inventory = inventory
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Cheese",
                Quantity = 10,
                LowStockThreshold = 3,
                Inventory = inventory
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Pasta",
                Quantity = 15,
                LowStockThreshold = 4,
                Inventory = inventory
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Salmon",
                Quantity = 2,
                LowStockThreshold = 3,
                Inventory = inventory
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Coffee Beans",
                Quantity = 25,
                LowStockThreshold = 5,
                Inventory = inventory
            }
        };

        db.Restaurants.Add(restaurant);
        db.Tables.AddRange(tables);
        db.Customers.AddRange(customers);
        db.Staff.AddRange(staff);
        db.Menus.Add(menu);
        db.MenuItems.AddRange(menuItems);
        db.Inventories.Add(inventory);
        db.Ingredients.AddRange(ingredients);

        await db.SaveChangesAsync();
    }
}