using Data.Restaurant.DTOs;
using Data.Restaurant.Entities;
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
        if (dto.CustomerId == Guid.Empty)
            throw new InvalidOperationException("Customer is required.");

        if (!dto.Items.Any())
            throw new InvalidOperationException("Order must contain at least one item.");

        var menuItemIds = dto.Items.Select(x => x.MenuItemId).ToList();

        var menuItems = await _db.MenuItems
            .Where(x => menuItemIds.Contains(x.Id))
            .ToListAsync();

        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = dto.CustomerId,
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

    public async Task<int> GetOrderCountAsync()
    {
        return await _db.Orders.CountAsync();
    }
}