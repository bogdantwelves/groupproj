namespace Data.Restaurant.DTOs;

public class CreateOrderDto
{
    public Guid CustomerId { get; set; }

    public Guid? ReservationId { get; set; }

    public List<CreateOrderItemDto> Items { get; set; } = new();
}