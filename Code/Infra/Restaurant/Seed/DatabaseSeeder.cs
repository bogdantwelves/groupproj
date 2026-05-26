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

        await Task.CompletedTask;
    }
}