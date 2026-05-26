using Data.Restaurant.DTOs;

namespace Domain.Restaurant.Interfaces;

public interface ITableService
{
    Task<List<TableDto>> GetTablesAsync();
}