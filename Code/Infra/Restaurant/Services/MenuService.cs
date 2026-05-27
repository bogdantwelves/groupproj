using Data.Restaurant.DTOs;
using Data.Restaurant.Entities;
using Domain.Restaurant.Interfaces;
using Infra.Restaurant.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Restaurant.Services;

public class MenuService : IMenuService
{
    private readonly AppDbContext _db;

    public MenuService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<MenuItemDto>> GetMenuItemsAsync()
    {
        return await _db.MenuItems
            .OrderBy(x => x.Name)
            .Select(x => new MenuItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price
            })
            .ToListAsync();
    }

    public async Task AddMenuItemAsync(CreateMenuItemDto dto)
    {
        var name = dto.Name.Trim();
        var description = dto.Description.Trim();

        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("Dish name is required.");

        if (dto.Price <= 0)
            throw new InvalidOperationException("Price must be greater than zero.");

        var menu = await _db.Menus
            .OrderBy(x => x.Id)
            .FirstOrDefaultAsync();

        if (menu is null)
            throw new InvalidOperationException("Menu not found.");

        _db.MenuItems.Add(new MenuItem
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Price = dto.Price,
            MenuId = menu.Id
        });

        await _db.SaveChangesAsync();
    }

    public async Task UpdateMenuItemAsync(Guid menuItemId, UpdateMenuItemDto dto)
    {
        if (menuItemId == Guid.Empty)
            throw new InvalidOperationException("Dish is required.");

        var name = dto.Name.Trim();
        var description = dto.Description.Trim();

        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("Dish name is required.");

        if (dto.Price <= 0)
            throw new InvalidOperationException("Price must be greater than zero.");

        var item = await _db.MenuItems
            .FirstOrDefaultAsync(x => x.Id == menuItemId);

        if (item is null)
            throw new InvalidOperationException("Dish not found.");

        item.Name = name;
        item.Description = description;
        item.Price = dto.Price;

        await _db.SaveChangesAsync();
    }

    public async Task DeleteMenuItemAsync(Guid menuItemId)
    {
        if (menuItemId == Guid.Empty)
            throw new InvalidOperationException("Dish is required.");

        var item = await _db.MenuItems
            .FirstOrDefaultAsync(x => x.Id == menuItemId);

        if (item is null)
            throw new InvalidOperationException("Dish not found.");

        _db.MenuItems.Remove(item);

        await _db.SaveChangesAsync();
    }
}
