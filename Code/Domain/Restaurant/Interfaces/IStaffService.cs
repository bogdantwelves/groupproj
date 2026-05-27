using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Restaurant.DTOs;

namespace Domain.Restaurant.Interfaces;

public interface IStaffService
{
    Task<List<StaffDto>> GetStaffAsync();

    Task<Guid> CreateStaffAsync(CreateStaffDto dto);

    Task UpdateStaffAsync(Guid staffId, UpdateStaffDto dto);

    Task DeleteStaffAsync(Guid staffId);
}
