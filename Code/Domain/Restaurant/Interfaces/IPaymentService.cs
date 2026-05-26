using Data.Restaurant.DTOs;

namespace Domain.Restaurant.Interfaces;

public interface IPaymentService
{
    Task PayAsync(PaymentDto dto);
}