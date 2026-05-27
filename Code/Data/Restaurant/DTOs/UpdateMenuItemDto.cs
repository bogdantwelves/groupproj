namespace Data.Restaurant.DTOs;

public class UpdateMenuItemDto
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }
}
