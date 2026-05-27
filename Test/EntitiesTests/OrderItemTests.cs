using System;
using Abc.Aids;
using Data.Restaurant.Entities;
using Data.Restaurant.Tests.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Entities;

[TestClass]
public class OrderItemTests : BaseTests<OrderItem>
{
    private Guid id;
    private Guid orderId;
    private Order? order;
    private Guid menuItemId;
    private MenuItem? menuItem;
    private int quantity;
    private decimal unitPrice;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        orderId = Guid.NewGuid();
        order = new Order();
        menuItemId = Guid.NewGuid();
        menuItem = new MenuItem();
        quantity = GetRandom.Int32();
        unitPrice = GetRandom.Decimal();
        obj.Id = id;
        obj.OrderId = orderId;
        obj.Order = order;
        obj.MenuItemId = menuItemId;
        obj.MenuItem = menuItem;
        obj.Quantity = quantity;
        obj.UnitPrice = unitPrice;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void OrderIdTest() => areEqual(orderId, obj.OrderId);
    [TestMethod] public void OrderTest() => areSame(order, obj.Order);
    [TestMethod] public void MenuItemIdTest() => areEqual(menuItemId, obj.MenuItemId);
    [TestMethod] public void MenuItemTest() => areSame(menuItem, obj.MenuItem);
    [TestMethod] public void QuantityTest() => areEqual(quantity, obj.Quantity);
    [TestMethod] public void UnitPriceTest() => areEqual(unitPrice, obj.UnitPrice);
}
