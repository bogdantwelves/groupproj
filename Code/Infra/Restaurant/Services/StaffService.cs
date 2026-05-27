using Data.Restaurant.DTOs;
using Domain.Restaurant.Interfaces;
using Infra.Restaurant.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Restaurant.Services;

public class StaffService : IStaffService
{
    private readonly AppDbContext _context;

    public StaffService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<StaffDto>> GetStaffAsync()
    {
        return await _context.Staff
            .Select(s => new StaffDto
            {
                Id = s.Id,
                FullName = s.FullName,
                Role = s.Role.ToString(),
                RestaurantId = s.RestaurantId
            })
            .ToListAsync();
    }
}
