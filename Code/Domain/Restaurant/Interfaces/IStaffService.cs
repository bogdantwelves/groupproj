using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Restaurant.DTOs;

namespace Domain.Restaurant.Interfaces;

public interface IStaffService
{
    Task<List<StaffDto>> GetStaffAsync();
}
