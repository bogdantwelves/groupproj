using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Restaurant.DTOs;
using Abc.Aids;

namespace Data.Restaurant.Tests.DTOs;

[TestClass] 
public class IngredientDtoTests : BaseTests<IngredientDto>
{
    [TestInitialize] 
    public override void Initialize()
    {
        base.Initialize();
        obj.Id = Guid.NewGuid();
        obj.Name = GetRandom.String();
        obj.Quantity = GetRandom.Decimal();
        obj.LowStockThreshold = GetRandom.Decimal();
    }

    [TestMethod] public void IdTest() => areEqual(obj.Id, obj.Id);
    [TestMethod] public void NameTest() => areEqual(obj.Name, obj.Name);
    [TestMethod] public void QuantityTest() => areEqual(obj.Quantity, obj.Quantity);
    [TestMethod] public void LowStockThresholdTest() => areEqual(obj.LowStockThreshold, obj.LowStockThreshold);
}