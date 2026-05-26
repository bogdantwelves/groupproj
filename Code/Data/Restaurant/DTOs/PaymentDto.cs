using Data.Restaurant.Enums;

namespace Data.Restaurant.DTOs;

public class PaymentDto
{
    public Guid OrderId { get; set; }

    public PaymentMethod Method { get; set; }
}