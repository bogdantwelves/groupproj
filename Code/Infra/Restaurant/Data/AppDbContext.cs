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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Feature-specific configuration will be added here.
    }
}