using Data.Restaurant.Enums;

namespace Data.Restaurant.Entities;

public class Staff
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public StaffRole Role { get; set; }

    public Guid RestaurantId { get; set; }

    public Restaurant? Restaurant { get; set; }
}