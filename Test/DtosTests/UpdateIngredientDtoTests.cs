using Abc.Aids;
using Data.Restaurant.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class UpdateIngredientDtoTests : BaseTests<UpdateIngredientDto>
{
    private string name = string.Empty;
    private decimal quantity;
    private decimal lowStockThreshold;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        name = GetRandom.String();
        quantity = GetRandom.Decimal();
        lowStockThreshold = GetRandom.Decimal();
        obj.Name = name;
        obj.Quantity = quantity;
        obj.LowStockThreshold = lowStockThreshold;
    }

    [TestMethod] public void NameTest() => areEqual(name, obj.Name);
    [TestMethod] public void QuantityTest() => areEqual(quantity, obj.Quantity);
    [TestMethod] public void LowStockThresholdTest() => areEqual(lowStockThreshold, obj.LowStockThreshold);
}
