using System;
using Abc.Aids;
using Data.Restaurant.Entities;
using Data.Restaurant.Enums;
using Data.Restaurant.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantEntity = Data.Restaurant.Entities.Restaurant;

namespace Data.Restaurant.Tests.Entities;

[TestClass]
public class StaffTests : BaseTests<Staff>
{
    private Guid id;
    private string fullName = string.Empty;
    private string shiftHours = string.Empty;
    private StaffRole role;
    private Guid restaurantId;
    private RestaurantEntity? restaurant;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        fullName = GetRandom.String();
        shiftHours = GetRandom.String();
        role = StaffRole.Manager;
        restaurantId = Guid.NewGuid();
        restaurant = new RestaurantEntity();
        obj.Id = id;
        obj.FullName = fullName;
        obj.ShiftHours = shiftHours;
        obj.Role = role;
        obj.RestaurantId = restaurantId;
        obj.Restaurant = restaurant;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void FullNameTest() => areEqual(fullName, obj.FullName);
    [TestMethod] public void ShiftHoursTest() => areEqual(shiftHours, obj.ShiftHours);
    [TestMethod] public void RoleTest() => areEqual(role, obj.Role);
    [TestMethod] public void RestaurantIdTest() => areEqual(restaurantId, obj.RestaurantId);
    [TestMethod] public void RestaurantTest() => areSame(restaurant, obj.Restaurant);
}
