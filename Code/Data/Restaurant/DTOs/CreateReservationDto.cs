namespace Data.Restaurant.DTOs;

public class CreateReservationDto
{
    public string CustomerName { get; set; } = string.Empty;

    public string RestaurantName { get; set; } = string.Empty;

    public DateTime DateTime { get; set; }

    public int PartySize { get; set; }
}
