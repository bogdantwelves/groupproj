using System;
using System.Collections.Generic;
using Data.Restaurant.Entities;
using Data.Restaurant.Tests.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantEntity = Data.Restaurant.Entities.Restaurant;

namespace Data.Restaurant.Tests.Entities;

[TestClass]
public class InventoryTests : BaseTests<Inventory>
{
    private Guid id;
    private Guid restaurantId;
    private RestaurantEntity? restaurant;
    private List<Ingredient> ingredients = new();

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        restaurantId = Guid.NewGuid();
        restaurant = new RestaurantEntity();
        ingredients = new List<Ingredient> { new() };
        obj.Id = id;
        obj.RestaurantId = restaurantId;
        obj.Restaurant = restaurant;
        obj.Ingredients = ingredients;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void RestaurantIdTest() => areEqual(restaurantId, obj.RestaurantId);
    [TestMethod] public void RestaurantTest() => areSame(restaurant, obj.Restaurant);
    [TestMethod] public void IngredientsTest() => areSame(ingredients, obj.Ingredients);
}
