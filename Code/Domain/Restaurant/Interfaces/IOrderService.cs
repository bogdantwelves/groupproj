using Data.Restaurant.DTOs;

namespace Domain.Restaurant.Interfaces;

public interface IOrderService
{
    Task CreateOrderAsync(CreateOrderDto dto);
}