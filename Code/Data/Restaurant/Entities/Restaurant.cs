namespace Data.Restaurant.Entities;

public class Restaurant
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public List<RestaurantTable> Tables { get; set; } = new();

    public List<Menu> Menus { get; set; } = new();

    public List<Reservation> Reservations { get; set; } = new();

    public List<Staff> Staff { get; set; } = new();

    public Inventory? Inventory { get; set; }
}