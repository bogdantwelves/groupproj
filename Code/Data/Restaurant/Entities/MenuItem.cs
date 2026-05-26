namespace Data.Restaurant.Entities;

public class MenuItem
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public Guid MenuId { get; set; }
    public Menu? Menu { get; set; }
}