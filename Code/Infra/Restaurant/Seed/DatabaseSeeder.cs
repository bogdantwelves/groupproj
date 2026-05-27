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
        var restaurantId = Guid.Parse("11111111-1111-1111-1111-111111111111");

        var customer1Id = Guid.Parse("22222222-2222-2222-2222-222222222221");
        var customer2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var customer3Id = Guid.Parse("22222222-2222-2222-2222-222222222223");

        var existingRestaurant = await db.Restaurants
            .FirstOrDefaultAsync(x => x.Id == restaurantId);

        if (existingRestaurant is null)
        {
            existingRestaurant = new RestaurantEntity
            {
                Id = restaurantId,
                Name = "Demo Restaurant",
                Address = "Main Street 1"
            };

            db.Restaurants.Add(existingRestaurant);

            await db.SaveChangesAsync();
        }

        if (!await db.Tables.AnyAsync())
        {
            var tables = new List<RestaurantTable>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    TableNumber = 1,
                    Capacity = 2,
                    IsAvailable = true,
                    RestaurantId = existingRestaurant.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    TableNumber = 2,
                    Capacity = 2,
                    IsAvailable = true,
                    RestaurantId = existingRestaurant.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    TableNumber = 3,
                    Capacity = 4,
                    IsAvailable = true,
                    RestaurantId = existingRestaurant.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    TableNumber = 4,
                    Capacity = 6,
                    IsAvailable = true,
                    RestaurantId = existingRestaurant.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    TableNumber = 5,
                    Capacity = 8,
                    IsAvailable = true,
                    RestaurantId = existingRestaurant.Id
                }
            };

            db.Tables.AddRange(tables);

            await db.SaveChangesAsync();
        }

        var customersToAdd = new List<Customer>();

        if (!await db.Customers.AnyAsync(x => x.Id == customer1Id))
        {
            customersToAdd.Add(new Customer
            {
                Id = customer1Id,
                FullName = "Alice Brown",
                Email = "alice@test.com",
                PhoneNumber = "111111"
            });
        }

        if (!await db.Customers.AnyAsync(x => x.Id == customer2Id))
        {
            customersToAdd.Add(new Customer
            {
                Id = customer2Id,
                FullName = "Bob Smith",
                Email = "bob@test.com",
                PhoneNumber = "222222"
            });
        }

        if (!await db.Customers.AnyAsync(x => x.Id == customer3Id))
        {
            customersToAdd.Add(new Customer
            {
                Id = customer3Id,
                FullName = "Charlie Green",
                Email = "charlie@test.com",
                PhoneNumber = "333333"
            });
        }

        if (customersToAdd.Count > 0)
        {
            db.Customers.AddRange(customersToAdd);
            await db.SaveChangesAsync();
        }

        if (!await db.Staff.AnyAsync())
        {
            var staff = new List<Staff>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Admin User",
                    Role = StaffRole.Admin,
                    RestaurantId = existingRestaurant.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    FullName = "John Waiter",
                    Role = StaffRole.Waiter,
                    RestaurantId = existingRestaurant.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Maria Chef",
                    Role = StaffRole.Chef,
                    RestaurantId = existingRestaurant.Id
                }
            };

            db.Staff.AddRange(staff);

            await db.SaveChangesAsync();
        }

        if (!await db.Menus.AnyAsync())
        {
            var menu = new Menu
            {
                Id = Guid.NewGuid(),
                Name = "Main Menu",
                RestaurantId = existingRestaurant.Id
            };

            db.Menus.Add(menu);

            await db.SaveChangesAsync();

            var menuItems = new List<MenuItem>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Caesar Salad",
                    Description = "Fresh salad with chicken",
                    Price = 7.50m,
                    MenuId = menu.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Tomato Soup",
                    Description = "Classic tomato soup",
                    Price = 5.00m,
                    MenuId = menu.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Burger",
                    Description = "Beef burger with fries",
                    Price = 11.90m,
                    MenuId = menu.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pasta Carbonara",
                    Description = "Pasta with creamy sauce",
                    Price = 12.50m,
                    MenuId = menu.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Grilled Salmon",
                    Description = "Salmon with vegetables",
                    Price = 18.00m,
                    MenuId = menu.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pizza Margherita",
                    Description = "Pizza with tomato and cheese",
                    Price = 10.00m,
                    MenuId = menu.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cheesecake",
                    Description = "Classic cheesecake",
                    Price = 6.00m,
                    MenuId = menu.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Coffee",
                    Description = "Black coffee",
                    Price = 3.00m,
                    MenuId = menu.Id
                }
            };

            db.MenuItems.AddRange(menuItems);

            await db.SaveChangesAsync();
        }

        if (!await db.Inventories.AnyAsync())
        {
            var inventory = new Inventory
            {
                Id = Guid.NewGuid(),
                RestaurantId = existingRestaurant.Id
            };

            db.Inventories.Add(inventory);

            await db.SaveChangesAsync();

            var ingredients = new List<Ingredient>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Tomatoes",
                    Quantity = 20,
                    LowStockThreshold = 5,
                    InventoryId = inventory.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cheese",
                    Quantity = 10,
                    LowStockThreshold = 3,
                    InventoryId = inventory.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pasta",
                    Quantity = 15,
                    LowStockThreshold = 4,
                    InventoryId = inventory.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Salmon",
                    Quantity = 2,
                    LowStockThreshold = 3,
                    InventoryId = inventory.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Coffee Beans",
                    Quantity = 25,
                    LowStockThreshold = 5,
                    InventoryId = inventory.Id
                }
            };

            db.Ingredients.AddRange(ingredients);

            await db.SaveChangesAsync();
        }
    }
}