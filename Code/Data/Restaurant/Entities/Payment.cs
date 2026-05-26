using Data.Restaurant.Enums;

namespace Data.Restaurant.Entities;

public class Payment
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }

    public PaymentStatus Status { get; set; }

    public PaymentMethod Method { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid OrderId { get; set; }

    public Order? Order { get; set; }
}
