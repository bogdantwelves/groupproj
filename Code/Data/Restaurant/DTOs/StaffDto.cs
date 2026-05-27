namespace Data.Restaurant.DTOs;

public class StaffDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public Guid RestaurantId { get; set; }
}
