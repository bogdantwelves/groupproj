namespace Data.Restaurant.DTOs;

public class CreateOrderDto
{
    public string CustomerName { get; set; } = string.Empty;

    public Guid? ReservationId { get; set; }

    public List<CreateOrderItemDto> Items { get; set; } = new();
}
