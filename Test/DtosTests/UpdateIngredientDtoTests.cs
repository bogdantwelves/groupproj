using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Restaurant.DTOs;
using Abc.Aids;

namespace Data.Restaurant.Tests.DTOs;

[TestClass] 
public class UpdateIngredientDtoTests : BaseTests<UpdateIngredientDto>
{
    [TestInitialize] 
    public override void Initialize()
    {
        base.Initialize();
        obj.Name = GetRandom.String();
        obj.Quantity = GetRandom.Decimal();
        obj.LowStockThreshold = GetRandom.Decimal();
    }

    [TestMethod] public void NameTest() => areEqual(obj.Name, obj.Name);
    [TestMethod] public void QuantityTest() => areEqual(obj.Quantity, obj.Quantity);
    [TestMethod] public void LowStockThresholdTest() => areEqual(obj.LowStockThreshold, obj.LowStockThreshold);
}