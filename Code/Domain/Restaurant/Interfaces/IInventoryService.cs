using Data.Restaurant.DTOs;

namespace Domain.Restaurant.Interfaces;

public interface IInventoryService
{
    Task<List<IngredientDto>> GetIngredientsAsync();

    Task AddIngredientAsync(CreateIngredientDto dto);
}
