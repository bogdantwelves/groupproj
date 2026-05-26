using Data.Restaurant.DTOs;
using Domain.Restaurant.Interfaces;
using Infra.Restaurant.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Restaurant.Services;

public class InventoryService : IInventoryService
{
    private readonly AppDbContext _db;

    public InventoryService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<IngredientDto>> GetIngredientsAsync()
    {
        return await _db.Ingredients
            .OrderBy(x => x.Name)
            .Select(x => new IngredientDto
            {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity,
                LowStockThreshold = x.LowStockThreshold
            })
            .ToListAsync();
    }
}