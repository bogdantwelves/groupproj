using System;
using Abc.Aids;
using Data.Restaurant.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class StaffDtoTests : BaseTests<StaffDto>
{
    private Guid id;
    private string fullName = string.Empty;
    private string shiftHours = string.Empty;
    private string role = string.Empty;
    private Guid restaurantId;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        fullName = GetRandom.String();
        shiftHours = GetRandom.String();
        role = GetRandom.String();
        restaurantId = Guid.NewGuid();
        obj.Id = id;
        obj.FullName = fullName;
        obj.ShiftHours = shiftHours;
        obj.Role = role;
        obj.RestaurantId = restaurantId;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void FullNameTest() => areEqual(fullName, obj.FullName);
    [TestMethod] public void ShiftHoursTest() => areEqual(shiftHours, obj.ShiftHours);
    [TestMethod] public void RoleTest() => areEqual(role, obj.Role);
    [TestMethod] public void RestaurantIdTest() => areEqual(restaurantId, obj.RestaurantId);
}
