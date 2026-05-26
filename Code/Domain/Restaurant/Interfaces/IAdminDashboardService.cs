using Data.Restaurant.DTOs;

namespace Domain.Restaurant.Interfaces;

public interface IAdminDashboardService
{
    Task<AdminDashboardDto> GetDashboardAsync();
}