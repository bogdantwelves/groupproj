using Data.Restaurant.DTOs;
using Data.Restaurant.Entities;
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

    public async Task AddIngredientAsync(CreateIngredientDto dto)
    {
        var name = dto.Name.Trim();

        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("Product name is required.");

        if (dto.Quantity <= 0)
            throw new InvalidOperationException("Quantity must be greater than zero.");

        var inventory = await _db.Inventories
            .OrderBy(x => x.Id)
            .FirstOrDefaultAsync();

        if (inventory is null)
            throw new InvalidOperationException("Inventory not found.");

        var existingIngredient = await _db.Ingredients
            .FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

        if (existingIngredient is not null)
        {
            existingIngredient.Quantity += dto.Quantity;
        }
        else
        {
            _db.Ingredients.Add(new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = name,
                Quantity = dto.Quantity,
                InventoryId = inventory.Id
            });
        }

        await _db.SaveChangesAsync();
    }
}
