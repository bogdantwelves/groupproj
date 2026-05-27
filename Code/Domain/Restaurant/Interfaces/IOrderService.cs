using Data.Restaurant.DTOs;
namespace Domain.Restaurant.Interfaces;

public interface IOrderService
{
    Task<Guid> CreateOrderAsync(CreateOrderDto dto);

    Task<decimal> GetOrderTotalAsync(Guid orderId);

    Task<int> GetOrderCountAsync();

    Task<List<OrderHistoryDto>> GetOrderHistoryAsync();
}
