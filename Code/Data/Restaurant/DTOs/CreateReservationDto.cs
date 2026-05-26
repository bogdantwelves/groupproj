namespace Data.Restaurant.DTOs;

public class CreateReservationDto
{
    public Guid CustomerId { get; set; }

    public Guid RestaurantId { get; set; }

    public DateTime DateTime { get; set; }

    public int PartySize { get; set; }
}