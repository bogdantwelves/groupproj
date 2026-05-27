namespace Data.Restaurant.DTOs;

public class UpdateIngredientDto
{
    public string Name { get; set; } = string.Empty;

    public decimal Quantity { get; set; }

    public decimal LowStockThreshold { get; set; }
}
