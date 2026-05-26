using Domain.Restaurant.Interfaces;
using Data.Restaurant.DTOs;
using Infra.Restaurant.Data;
using Microsoft.EntityFrameworkCore;

public class MenuService : IMenuService
{
    private readonly AppDbContext _db;

    public MenuService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<MenuItemDto>> GetMenuAsync()
    {
        return await _db.MenuItems
            .Select(x => new MenuItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            })
            .ToListAsync();
    }
}