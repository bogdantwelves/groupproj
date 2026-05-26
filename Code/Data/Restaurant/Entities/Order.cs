using Data.Restaurant.Enums;

namespace Data.Restaurant.Entities;

public class Order
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public OrderStatus Status { get; set; } = OrderStatus.Created;

    public Guid CustomerId { get; set; }

    public Customer? Customer { get; set; }

    public Guid? ReservationId { get; set; }

    public Reservation? Reservation { get; set; }

    public List<OrderItem> Items { get; set; } = new();

    public Payment? Payment { get; set; }

    public decimal TotalAmount => Items.Sum(x => x.UnitPrice * x.Quantity);
}