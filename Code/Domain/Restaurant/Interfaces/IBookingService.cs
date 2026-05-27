using Data.Restaurant.DTOs;

namespace Domain.Restaurant.Interfaces;

public interface IBookingService
{
    Task CreateReservationAsync(CreateReservationDto dto);

    Task<List<ReservationDto>> GetAllReservationsAsync();

    Task<List<ReservationDto>> GetReservationsByCustomerAsync(string customerName);

    Task UpdateReservationAsync(Guid reservationId, UpdateReservationDto dto);

    Task CancelReservationAsync(Guid reservationId);

    Task DeleteReservationAsync(Guid reservationId);
}
