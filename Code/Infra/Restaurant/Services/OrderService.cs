using Data.Restaurant.DTOs;
using Data.Restaurant.Entities;
using Data.Restaurant.Enums;
using Domain.Restaurant.Interfaces;
using Infra.Restaurant.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Restaurant.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _db;

    public OrderService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Guid> CreateOrderAsync(CreateOrderDto dto)
    {
        var customerName = dto.CustomerName.Trim();

        if (string.IsNullOrWhiteSpace(customerName))
            throw new InvalidOperationException("Customer name is required.");

        var customer = await _db.Customers
            .FirstOrDefaultAsync(x => x.FullName == customerName);

        if (customer is null)
        {
            customer = new Customer
            {
                Id = Guid.NewGuid(),
                FullName = customerName
            };

            _db.Customers.Add(customer);
        }

        if (dto.ReservationId is not null)
        {
            var reservationExists = await _db.Reservations.AnyAsync(x => x.Id == dto.ReservationId);
            if (!reservationExists)
                throw new InvalidOperationException("Reservation not found.");
        }

        if (!dto.Items.Any())
            throw new InvalidOperationException("Order must contain at least one item.");

        var menuItemIds = dto.Items.Select(x => x.MenuItemId).ToList();

        var menuItems = await _db.MenuItems
            .Where(x => menuItemIds.Contains(x.Id))
            .ToListAsync();

        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id,
            ReservationId = dto.ReservationId,
            CreatedAt = DateTime.UtcNow
        };

        foreach (var item in dto.Items)
        {
            if (item.Quantity <= 0)
                throw new InvalidOperationException("Order item quantity must be greater than zero.");

            var menuItem = menuItems.FirstOrDefault(x => x.Id == item.MenuItemId);

            if (menuItem is null)
                throw new InvalidOperationException("Menu item not found.");

            order.Items.Add(new OrderItem
            {
                Id = Guid.NewGuid(),
                MenuItemId = menuItem.Id,
                Quantity = item.Quantity,
                UnitPrice = menuItem.Price
            });
        }

        _db.Orders.Add(order);

        await _db.SaveChangesAsync();

        return order.Id;
    }

    public async Task<decimal> GetOrderTotalAsync(Guid orderId)
    {
        if (orderId == Guid.Empty)
            throw new InvalidOperationException("Order is required.");

        var orderExists = await _db.Orders.AnyAsync(x => x.Id == orderId);
        if (!orderExists)
            throw new InvalidOperationException("Order not found.");

        var total = await _db.OrderItems
            .AsNoTracking()
            .Where(x => x.OrderId == orderId)
            .Select(x => (decimal?)(x.UnitPrice * x.Quantity))
            .SumAsync();

        return total ?? 0m;
    }

    public async Task<int> GetOrderCountAsync()
    {
        return await _db.Orders.CountAsync();
    }

    public async Task<List<OrderHistoryDto>> GetOrderHistoryAsync()
    {
        return await _db.Orders
            .Include(x => x.Customer)
            .Include(x => x.Items)
            .Include(x => x.Payment)
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new OrderHistoryDto
            {
                OrderId = x.Id,
                CustomerName = x.Customer != null
                    ? x.Customer.FullName
                    : "Unknown",
                TotalAmount = x.Items.Sum(i => i.UnitPrice * i.Quantity),
                PaymentMethod = x.Payment != null
                    ? x.Payment.Method.ToString()
                    : "-",
                PaymentState = x.Payment != null && x.Payment.Status == PaymentStatus.Paid
                    ? "Paid"
                    : "Unpaid",
                CreatedAt = x.CreatedAt
            })
            .ToListAsync();
    }
}
