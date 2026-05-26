namespace Data.Restaurant.Entities;

public class Inventory
{
    public Guid Id { get; set; }

    public Guid RestaurantId { get; set; }

    public Restaurant? Restaurant { get; set; }

    public List<Ingredient> Ingredients { get; set; } = new();
}