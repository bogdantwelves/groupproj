using Data.Restaurant.DTOs;

namespace Domain.Restaurant.Interfaces;

public interface IBookingService
{
    Task CreateReservationAsync(CreateReservationDto dto);

    Task<List<ReservationDto>> GetReservationsByCustomerAsync(string customerName);

    Task CancelReservationAsync(Guid reservationId);
}
