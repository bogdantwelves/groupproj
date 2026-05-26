using Infra.Restaurant.Data;

namespace Infra.Restaurant.Seed;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        // Person 4: Restaurant, Tables, Inventory
        // Person 1: Customers
        public static async Task SeedAsync(AppDbContext db)
    {
        if (await db.Customers.AnyAsync())
        {
            return;
        }

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

        db.Customers.AddRange(customers);
        // Person 2: Menu and MenuItems
        // Person 3: Staff
        if (await db.Staff.AnyAsync())
        {
            return;
        }

        var restaurant = await db.Restaurants.FirstOrDefaultAsync();

        if (restaurant is null)
        {
            // Staff must belong to a restaurant.
            // If restaurant seed data has not been added yet, we skip staff seeding.
            return;
        }

        var staff = new List<Staff>
        {
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "Admin User",
                Role = StaffRole.Admin,
                RestaurantId = restaurant.Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "John Waiter",
                Role = StaffRole.Waiter,
                RestaurantId = restaurant.Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "Maria Chef",
                Role = StaffRole.Chef,
                RestaurantId = restaurant.Id
            }
        };

        db.Staff.AddRange(staff);

        await Task.CompletedTask;
    }
}