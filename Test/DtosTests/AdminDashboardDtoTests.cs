using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Restaurant.DTOs;
using Abc.Aids;

namespace Data.Restaurant.Tests.DTOs;

[TestClass] 
public class AdminDashboardDtoTests : BaseTests<AdminDashboardDto>
{
    [TestInitialize] 
    public override void Initialize()
    {
        base.Initialize();
        obj.ReservationCount = GetRandom.Int32();
        obj.OrderCount = GetRandom.Int32();
        obj.AvailableTables = GetRandom.Int32();
        obj.LowStockIngredients = GetRandom.Int32();
    }

    [TestMethod] public void ReservationCountTest() => areEqual(obj.ReservationCount, obj.ReservationCount);
    [TestMethod] public void OrderCountTest() => areEqual(obj.OrderCount, obj.OrderCount);
    [TestMethod] public void AvailableTablesTest() => areEqual(obj.AvailableTables, obj.AvailableTables);
    [TestMethod] public void LowStockIngredientsTest() => areEqual(obj.LowStockIngredients, obj.LowStockIngredients);
}