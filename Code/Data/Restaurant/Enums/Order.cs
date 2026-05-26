using Data.Restaurant.Enums;

namespace Data.Restaurant.Entities;

public class Order
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public Guid CustomerId { get; set; }
    //public Customer? Customer { get; set; }

    public List<OrderItem> Items { get; set; } = new();
}