using System;
using Abc.Aids;
using Data.Restaurant.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class CreateOrderItemDtoTests : BaseTests<CreateOrderItemDto>
{
    private Guid menuItemId;
    private int quantity;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        menuItemId = Guid.NewGuid();
        quantity = GetRandom.Int32();
        obj.MenuItemId = menuItemId;
        obj.Quantity = quantity;
    }

    [TestMethod] public void MenuItemIdTest() => areEqual(menuItemId, obj.MenuItemId);
    [TestMethod] public void QuantityTest() => areEqual(quantity, obj.Quantity);
}
