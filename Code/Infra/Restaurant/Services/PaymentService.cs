using Data.Restaurant.DTOs;
using Data.Restaurant.Entities;
using Data.Restaurant.Enums;
using Domain.Restaurant.Interfaces;
using Infra.Restaurant.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Restaurant.Services;

public class PaymentService : IPaymentService
{
    private readonly AppDbContext _db;

    public PaymentService(AppDbContext db)
    {
        _db = db;
    }

    public async Task PayAsync(PaymentDto dto)
    {
        if (dto.OrderId == Guid.Empty)
            throw new InvalidOperationException("Order is required.");

        var order = await _db.Orders
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == dto.OrderId);

        if (order is null)
            throw new InvalidOperationException("Order not found.");

        if (!order.Items.Any())
            throw new InvalidOperationException("Order has no items.");

        var alreadyPaid = await _db.Payments
            .AnyAsync(x => x.OrderId == dto.OrderId && x.Status == PaymentStatus.Paid);

        if (alreadyPaid)
            throw new InvalidOperationException("Order is already paid.");

        var amount = order.Items.Sum(x => x.UnitPrice * x.Quantity);

        var payment = new Payment
        {
            Id = Guid.NewGuid(),
            OrderId = order.Id,
            Amount = amount,
            Method = dto.Method,
            Status = PaymentStatus.Paid,
            CreatedAt = DateTime.UtcNow
        };

        order.Status = OrderStatus.Paid;

        _db.Payments.Add(payment);

        await _db.SaveChangesAsync();
    }
}