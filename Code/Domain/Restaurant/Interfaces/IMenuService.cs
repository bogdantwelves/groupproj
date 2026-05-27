using Data.Restaurant.DTOs;

namespace Domain.Restaurant.Interfaces;

public interface IMenuService
{
    Task<List<MenuItemDto>> GetMenuItemsAsync();

    Task AddMenuItemAsync(CreateMenuItemDto dto);

    Task UpdateMenuItemAsync(Guid menuItemId, UpdateMenuItemDto dto);

    Task DeleteMenuItemAsync(Guid menuItemId);
}
