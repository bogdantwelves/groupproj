using System;
using Abc.Aids;
using Data.Restaurant.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class MenuItemDtoTests : BaseTests<MenuItemDto>
{
    private Guid id;
    private string name = string.Empty;
    private string description = string.Empty;
    private decimal price;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        name = GetRandom.String();
        description = GetRandom.String();
        price = GetRandom.Decimal();
        obj.Id = id;
        obj.Name = name;
        obj.Description = description;
        obj.Price = price;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void NameTest() => areEqual(name, obj.Name);
    [TestMethod] public void DescriptionTest() => areEqual(description, obj.Description);
    [TestMethod] public void PriceTest() => areEqual(price, obj.Price);
}
