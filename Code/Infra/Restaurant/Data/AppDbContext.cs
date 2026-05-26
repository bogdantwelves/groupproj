using Data.Restaurant.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Restaurant.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Person 1: Reservations

    // Person 2: Menu and Orders

    // Person 3: Payments and Admin

    // Person 4: Tables and Inventory
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    public DbSet<RestaurantTable> Tables => Set<RestaurantTable>();
    public DbSet<Inventory> Inventories => Set<Inventory>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Feature-specific configuration will be added here.
        modelBuilder.Entity<MenuItem>()
            .Property(x => x.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<OrderItem>()
            .Property(x => x.UnitPrice)
            .HasPrecision(18, 2);
    }
}