using Data.Restaurant.DTOs;
using Data.Restaurant.Entities;
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
                ShiftHours = s.ShiftHours,
                Role = s.Role.ToString(),
                RestaurantId = s.RestaurantId
            })
            .ToListAsync();
    }

    public async Task<Guid> CreateStaffAsync(CreateStaffDto dto)
    {
        var fullName = dto.FullName.Trim();
        if (string.IsNullOrWhiteSpace(fullName))
            throw new InvalidOperationException("Full name is required.");

        if (dto.RestaurantId == Guid.Empty)
            throw new InvalidOperationException("Restaurant is required.");

        var restaurantExists = await _context.Restaurants.AnyAsync(x => x.Id == dto.RestaurantId);
        if (!restaurantExists)
            throw new InvalidOperationException("Restaurant not found.");

        var staff = new Staff
        {
            Id = Guid.NewGuid(),
            FullName = fullName,
            ShiftHours = dto.ShiftHours.Trim(),
            Role = dto.Role,
            RestaurantId = dto.RestaurantId
        };

        _context.Staff.Add(staff);
        await _context.SaveChangesAsync();

        return staff.Id;
    }

    public async Task UpdateStaffAsync(Guid staffId, UpdateStaffDto dto)
    {
        if (staffId == Guid.Empty)
            throw new InvalidOperationException("Staff member is required.");

        var fullName = dto.FullName.Trim();
        if (string.IsNullOrWhiteSpace(fullName))
            throw new InvalidOperationException("Full name is required.");

        var shiftHours = dto.ShiftHours.Trim();

        var staff = await _context.Staff
            .FirstOrDefaultAsync(x => x.Id == staffId);

        if (staff is null)
            throw new InvalidOperationException("Staff member not found.");

        staff.FullName = fullName;
        staff.Role = dto.Role;
        staff.ShiftHours = shiftHours;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteStaffAsync(Guid staffId)
    {
        if (staffId == Guid.Empty)
            throw new InvalidOperationException("Staff member is required.");

        var staff = await _context.Staff
            .FirstOrDefaultAsync(x => x.Id == staffId);

        if (staff is null)
            throw new InvalidOperationException("Staff member not found.");

        _context.Staff.Remove(staff);

        await _context.SaveChangesAsync();
    }
}
