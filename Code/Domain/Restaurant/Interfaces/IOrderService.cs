using Data.Restaurant.DTOs;
namespace Domain.Restaurant.Interfaces;

public interface IOrderService
{
    Task<Guid> CreateOrderAsync(CreateOrderDto dto);

    Task<int> GetOrderCountAsync();
}