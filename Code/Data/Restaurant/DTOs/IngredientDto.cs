namespace Data.Restaurant.DTOs;

public class IngredientDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Quantity { get; set; }

    public decimal LowStockThreshold { get; set; }
}