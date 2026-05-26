using Data.Restaurant.DTOs;

namespace Domain.Restaurant.Interfaces;

public interface IBookingService
{
    Task CreateReservationAsync(CreateReservationDto dto);

    Task<List<ReservationDto>> GetReservationsByCustomerAsync(Guid customerId);

    Task CancelReservationAsync(Guid reservationId);
}