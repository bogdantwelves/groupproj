using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Restaurant.DTOs;
using Abc.Aids;

namespace Data.Restaurant.Tests.DTOs;

[TestClass] 
public class CreateOrderItemDtoTests : BaseTests<CreateOrderItemDto>
{
    [TestInitialize] 
    public override void Initialize()
    {
        base.Initialize();
        obj.MenuItemId = Guid.NewGuid();
        obj.Quantity = GetRandom.Int32();
    }

    [TestMethod] public void MenuItemIdTest() => areEqual(obj.MenuItemId, obj.MenuItemId);
    [TestMethod] public void QuantityTest() => areEqual(obj.Quantity, obj.Quantity);
}