using Data.Restaurant.Enums;

namespace Data.Restaurant.DTOs;

public class ReservationDto
{
    public Guid Id { get; set; }

    public DateTime DateTime { get; set; }

    public int? TableNumber { get; set; }

    public int PartySize { get; set; }

    public ReservationStatus Status { get; set; }
}