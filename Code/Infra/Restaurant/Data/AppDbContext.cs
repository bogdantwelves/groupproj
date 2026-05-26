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
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Staff> Staff => Set<Staff>();

    // Person 4: Tables and Inventory

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Payment>()
            .Property(x => x.Amount)
            .HasPrecision(18, 2);
    }
}