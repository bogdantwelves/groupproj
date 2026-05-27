namespace Data.Restaurant.DTOs;

public class OrderHistoryDto
{
    public Guid OrderId { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }

    public string PaymentMethod { get; set; } = "-";

    public string PaymentState { get; set; } = "Unpaid";

    public DateTime CreatedAt { get; set; }
}
