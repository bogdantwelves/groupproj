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
        var customerName = dto.CustomerName.Trim();

        if (string.IsNullOrWhiteSpace(customerName))
            throw new InvalidOperationException("Customer name is required.");

        var restaurantName = dto.RestaurantName.Trim();

        if (string.IsNullOrWhiteSpace(restaurantName))
            throw new InvalidOperationException("Restaurant name is required.");

        if (dto.PartySize <= 0)
            throw new InvalidOperationException("Party size must be greater than zero.");

        if (dto.DateTime <= DateTime.Now)
            throw new InvalidOperationException("Reservation date must be in the future.");

        var customer = await _db.Customers
            .FirstOrDefaultAsync(x => x.FullName == customerName);

        if (customer is null)
        {
            customer = new Customer
            {
                Id = Guid.NewGuid(),
                FullName = customerName
            };

            _db.Customers.Add(customer);
        }

        var restaurant = await _db.Restaurants
            .FirstOrDefaultAsync(x => x.Name == restaurantName);

        if (restaurant is null)
            throw new InvalidOperationException("Restaurant not found.");

        var table = await _db.Tables
            .Where(x =>
                x.RestaurantId == restaurant.Id &&
                x.IsAvailable &&
                x.Capacity >= dto.PartySize)
            .OrderBy(x => x.Capacity)
            .FirstOrDefaultAsync();

        var reservation = new Reservation
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id,
            RestaurantId = restaurant.Id,
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

    public async Task<List<ReservationDto>> GetReservationsByCustomerAsync(string customerName)
    {
        var normalizedCustomerName = customerName.Trim();

        if (string.IsNullOrWhiteSpace(normalizedCustomerName))
            throw new InvalidOperationException("Customer name is required.");

        var customer = await _db.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.FullName == normalizedCustomerName);

        if (customer is null)
            return new List<ReservationDto>();

        return await _db.Reservations
            .Include(x => x.RestaurantTable)
            .Where(x => x.CustomerId == customer.Id)
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
