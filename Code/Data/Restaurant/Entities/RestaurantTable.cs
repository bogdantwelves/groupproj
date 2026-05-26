namespace Data.Restaurant.Entities;

public class RestaurantTable
{
    public Guid Id { get; set; }

    public int TableNumber { get; set; }

    public int Capacity { get; set; }

    public bool IsAvailable { get; set; } = true;

    public Guid RestaurantId { get; set; }

    public Restaurant? Restaurant { get; set; }

    public List<Reservation> Reservations { get; set; } = new();
}