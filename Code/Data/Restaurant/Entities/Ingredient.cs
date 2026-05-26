namespace Data.Restaurant.Entities;

public class Ingredient
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Quantity { get; set; }

    public decimal LowStockThreshold { get; set; }

    public Guid InventoryId { get; set; }

    public Inventory? Inventory { get; set; }
}