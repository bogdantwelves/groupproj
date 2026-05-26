using Data.Restaurant.DTOs;

namespace Domain.Restaurant.Interfaces;

public interface IMenuService
{
    Task<List<MenuItemDto>> GetMenuItemsAsync();
}