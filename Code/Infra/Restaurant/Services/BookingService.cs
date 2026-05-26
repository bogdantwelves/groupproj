using Data.Restaurant.DTOs;
using Data.Restaurant.Entities;
using Data.Restaurant.Enums;
using Domain.Restaurant.Interfaces;
using Infra.Restaurant.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Restaurant.Services;

public class BookingService : IBookingService
{
    private readonly AppDbContext _db;

    public BookingService(AppDbContext db)
    {
        _db = db;
    }

    public async Task CreateReservationAsync(CreateReservationDto dto)
    {
        if (dto.CustomerId == Guid.Empty)
            throw new InvalidOperationException("Customer is required.");

        if (dto.RestaurantId == Guid.Empty)
            throw new InvalidOperationException("Restaurant is required.");

        if (dto.PartySize <= 0)
            throw new InvalidOperationException("Party size must be greater than zero.");

        if (dto.DateTime <= DateTime.Now)
            throw new InvalidOperationException("Reservation date must be in the future.");

        var customerExists = await _db.Customers.AnyAsync(x => x.Id == dto.CustomerId);

        if (!customerExists)
            throw new InvalidOperationException("Customer not found.");

        var restaurantExists = await _db.Restaurants.AnyAsync(x => x.Id == dto.RestaurantId);

        if (!restaurantExists)
            throw new InvalidOperationException("Restaurant not found.");

        var table = await _db.Tables
            .Where(x =>
                x.RestaurantId == dto.RestaurantId &&
                x.IsAvailable &&
                x.Capacity >= dto.PartySize)
            .OrderBy(x => x.Capacity)
            .FirstOrDefaultAsync();

        var reservation = new Reservation
        {
            Id = Guid.NewGuid(),
            CustomerId = dto.CustomerId,
            RestaurantId = dto.RestaurantId,
            DateTime = dto.DateTime,
            PartySize = dto.PartySize,
            Status = table is null ? ReservationStatus.Pending : ReservationStatus.Confirmed,
            RestaurantTableId = table?.Id
        };

        if (table is not null)
            table.IsAvailable = false;

        _db.Reservations.Add(reservation);

        await _db.SaveChangesAsync();
    }

    public async Task<List<ReservationDto>> GetReservationsByCustomerAsync(Guid customerId)
    {
        if (customerId == Guid.Empty)
            throw new InvalidOperationException("Customer is required.");

        return await _db.Reservations
            .Include(x => x.RestaurantTable)
            .Where(x => x.CustomerId == customerId)
            .OrderByDescending(x => x.DateTime)
            .Select(x => new ReservationDto
            {
                Id = x.Id,
                DateTime = x.DateTime,
                PartySize = x.PartySize,
                Status = x.Status,
                TableNumber = x.RestaurantTable != null
                    ? x.RestaurantTable.TableNumber
                    : null
            })
            .ToListAsync();
    }

    public async Task CancelReservationAsync(Guid reservationId)
    {
        if (reservationId == Guid.Empty)
            throw new InvalidOperationException("Reservation is required.");

        var reservation = await _db.Reservations
            .Include(x => x.RestaurantTable)
            .FirstOrDefaultAsync(x => x.Id == reservationId);

        if (reservation is null)
            throw new InvalidOperationException("Reservation not found.");

        if (reservation.Status == ReservationStatus.Cancelled)
            throw new InvalidOperationException("Reservation is already cancelled.");

        reservation.Status = ReservationStatus.Cancelled;

        if (reservation.RestaurantTable is not null)
            reservation.RestaurantTable.IsAvailable = true;

        await _db.SaveChangesAsync();
    }
}