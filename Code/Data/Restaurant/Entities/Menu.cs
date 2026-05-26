namespace Data.Restaurant.Entities;

public class Menu
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<MenuItem> Items { get; set; } = new();
}