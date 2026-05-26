using Data.Restaurant.Entities;
using Microsoft.EntityFrameworkCore;
using RestaurantEntity = Data.Restaurant.Entities.Restaurant;

namespace Infra.Restaurant.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<RestaurantEntity> Restaurants => Set<RestaurantEntity>();
    public DbSet<RestaurantTable> Tables => Set<RestaurantTable>();

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Staff> Staff => Set<Staff>();

    public DbSet<Menu> Menus => Set<Menu>();

    public DbSet<MenuItem> MenuItems => Set<MenuItem>();

    public DbSet<Reservation> Reservations => Set<Reservation>();

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    public DbSet<Payment> Payments => Set<Payment>();

    public DbSet<Inventory> Inventories => Set<Inventory>();

    public DbSet<Ingredient> Ingredients => Set<Ingredient>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MenuItem>()
            .Property(x => x.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<OrderItem>()
            .Property(x => x.UnitPrice)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Payment>()
            .Property(x => x.Amount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Ingredient>()
            .Property(x => x.Quantity)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Ingredient>()
            .Property(x => x.LowStockThreshold)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Order>()
            .Ignore(x => x.TotalAmount);
    }
}