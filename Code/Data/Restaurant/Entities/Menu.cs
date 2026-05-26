namespace Data.Restaurant.Entities;

public class Menu
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public Guid RestaurantId { get; set; }

    public Restaurant? Restaurant { get; set; }

    public List<MenuItem> Items { get; set; } = new();
}