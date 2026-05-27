using Abc.Aids;
using Data.Restaurant.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class AdminDashboardDtoTests : BaseTests<AdminDashboardDto>
{
    private int reservationCount;
    private int orderCount;
    private int availableTables;
    private int lowStockIngredients;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        reservationCount = GetRandom.Int32();
        orderCount = GetRandom.Int32();
        availableTables = GetRandom.Int32();
        lowStockIngredients = GetRandom.Int32();
        obj.ReservationCount = reservationCount;
        obj.OrderCount = orderCount;
        obj.AvailableTables = availableTables;
        obj.LowStockIngredients = lowStockIngredients;
    }

    [TestMethod] public void ReservationCountTest() => areEqual(reservationCount, obj.ReservationCount);
    [TestMethod] public void OrderCountTest() => areEqual(orderCount, obj.OrderCount);
    [TestMethod] public void AvailableTablesTest() => areEqual(availableTables, obj.AvailableTables);
    [TestMethod] public void LowStockIngredientsTest() => areEqual(lowStockIngredients, obj.LowStockIngredients);
}
