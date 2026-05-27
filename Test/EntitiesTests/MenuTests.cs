using System;
using System.Collections.Generic;
using Abc.Aids;
using Data.Restaurant.Entities;
using Data.Restaurant.Tests.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantEntity = Data.Restaurant.Entities.Restaurant;

namespace Data.Restaurant.Tests.Entities;

[TestClass]
public class MenuTests : BaseTests<Menu>
{
    private Guid id;
    private string name = string.Empty;
    private Guid restaurantId;
    private RestaurantEntity? restaurant;
    private List<MenuItem> items = new();

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        name = GetRandom.String();
        restaurantId = Guid.NewGuid();
        restaurant = new RestaurantEntity();
        items = new List<MenuItem> { new() };
        obj.Id = id;
        obj.Name = name;
        obj.RestaurantId = restaurantId;
        obj.Restaurant = restaurant;
        obj.Items = items;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void NameTest() => areEqual(name, obj.Name);
    [TestMethod] public void RestaurantIdTest() => areEqual(restaurantId, obj.RestaurantId);
    [TestMethod] public void RestaurantTest() => areSame(restaurant, obj.Restaurant);
    [TestMethod] public void ItemsTest() => areSame(items, obj.Items);
}
