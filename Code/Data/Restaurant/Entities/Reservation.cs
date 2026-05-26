using Data.Restaurant.Enums;

namespace Data.Restaurant.Entities;

public class Reservation
{
    public Guid Id { get; set; }

    public DateTime DateTime { get; set; }

    public int PartySize { get; set; }

    public ReservationStatus Status { get; set; } = ReservationStatus.Pending;

    public Guid CustomerId { get; set; }

    public Customer? Customer { get; set; }

    public Guid RestaurantId { get; set; }

    public Restaurant? Restaurant { get; set; }

    public Guid? RestaurantTableId { get; set; }

    public RestaurantTable? RestaurantTable { get; set; }
}