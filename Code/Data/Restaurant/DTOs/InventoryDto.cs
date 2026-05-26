namespace Data.Restaurant.DTOs;

public class InventoryDto
{
    public Guid Id { get; set; }

    public List<IngredientDto> Ingredients { get; set; } = new();
}