using Data.Restaurant.DTOs;
using Domain.Restaurant.Interfaces;
using Infra.Restaurant.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Restaurant.Services;

public class AdminDashboardService : IAdminDashboardService
{
    private readonly AppDbContext _db;

    public AdminDashboardService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<AdminDashboardDto> GetDashboardAsync()
    {
        return new AdminDashboardDto
        {
            ReservationCount = await _db.Reservations.CountAsync(),
            OrderCount = 0,
            AvailableTables = 0,
            LowStockIngredients = 0
        };
    }
}