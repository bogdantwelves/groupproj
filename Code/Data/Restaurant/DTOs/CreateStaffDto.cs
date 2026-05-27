using Data.Restaurant.Enums;

namespace Data.Restaurant.DTOs;

public class CreateStaffDto
{
    public string FullName { get; set; } = string.Empty;

    public string ShiftHours { get; set; } = string.Empty;

    public StaffRole Role { get; set; } = StaffRole.Waiter;

    public Guid RestaurantId { get; set; }
}
