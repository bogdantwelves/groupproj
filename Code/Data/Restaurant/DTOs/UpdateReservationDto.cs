namespace Data.Restaurant.DTOs;

public class UpdateReservationDto
{
    public string CustomerName { get; set; } = string.Empty;

    public DateTime DateTime { get; set; }
}
