namespace Data.Restaurant.DTOs;

public class AdminDashboardDto
{
    public int ReservationCount { get; set; }

    public int OrderCount { get; set; }

    public int AvailableTables { get; set; }

    public int LowStockIngredients { get; set; }
}