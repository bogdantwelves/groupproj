using Data.Restaurant.DTOs;
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
}