using Data.Restaurant.DTOs;
using Data.Restaurant.Entities;
using Data.Restaurant.Enums;
using Domain.Restaurant.Interfaces;
using Infra.Restaurant.Data;

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

        var payment = new Payment
        {
            Id = Guid.NewGuid(),
            OrderId = dto.OrderId,
            Amount = 0m,
            Method = dto.Method,
            Status = PaymentStatus.Paid,
            CreatedAt = DateTime.UtcNow
        };

        _db.Payments.Add(payment);

        await _db.SaveChangesAsync();
    }
}