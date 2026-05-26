namespace Data.Restaurant.DTOs;

public class TableDto
{
    public Guid Id { get; set; }

    public int TableNumber { get; set; }

    public int Capacity { get; set; }

    public bool IsAvailable { get; set; }
}