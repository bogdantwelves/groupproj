namespace Data.Restaurant.Entities;

public class Customer
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public List<Reservation> Reservations { get; set; } = new();

    public List<Order> Orders { get; set; } = new();
}