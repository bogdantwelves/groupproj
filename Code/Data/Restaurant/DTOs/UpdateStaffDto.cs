using Data.Restaurant.Enums;

namespace Data.Restaurant.DTOs;

public class UpdateStaffDto
{
    public string FullName { get; set; } = string.Empty;

    public StaffRole Role { get; set; }

    public string ShiftHours { get; set; } = string.Empty;
}
