using Data.Restaurant.DTOs;
using Domain.Restaurant.Interfaces;
using Infra.Restaurant.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Restaurant.Services;

public class TableService : ITableService
{
    private readonly AppDbContext _db;

    public TableService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<TableDto>> GetTablesAsync()
    {
        return await _db.Tables
            .OrderBy(x => x.TableNumber)
            .Select(x => new TableDto
            {
                Id = x.Id,
                TableNumber = x.TableNumber,
                Capacity = x.Capacity,
                IsAvailable = x.IsAvailable
            })
            .ToListAsync();
    }
}