using System;
using System.Collections.Generic;
using Abc.Aids;
using Data.Restaurant.Entities;
using Data.Restaurant.Tests.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Entities;

[TestClass]
public class MenuItemTests : BaseTests<MenuItem>
{
    private Guid id;
    private string name = string.Empty;
    private string description = string.Empty;
    private decimal price;
    private Guid menuId;
    private Menu? menu;
    private List<OrderItem> orderItems = new();

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        name = GetRandom.String();
        description = GetRandom.String();
        price = GetRandom.Decimal();
        menuId = Guid.NewGuid();
        menu = new Menu();
        orderItems = new List<OrderItem> { new() };
        obj.Id = id;
        obj.Name = name;
        obj.Description = description;
        obj.Price = price;
        obj.MenuId = menuId;
        obj.Menu = menu;
        obj.OrderItems = orderItems;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void NameTest() => areEqual(name, obj.Name);
    [TestMethod] public void DescriptionTest() => areEqual(description, obj.Description);
    [TestMethod] public void PriceTest() => areEqual(price, obj.Price);
    [TestMethod] public void MenuIdTest() => areEqual(menuId, obj.MenuId);
    [TestMethod] public void MenuTest() => areSame(menu, obj.Menu);
    [TestMethod] public void OrderItemsTest() => areSame(orderItems, obj.OrderItems);
}
