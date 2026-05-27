using System;
using Abc.Aids;
using Data.Restaurant.DTOs;
using Data.Restaurant.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class CreateStaffDtoTests : BaseTests<CreateStaffDto>
{
    private string fullName = string.Empty;
    private string shiftHours = string.Empty;
    private StaffRole role;
    private Guid restaurantId;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        fullName = GetRandom.String();
        shiftHours = GetRandom.String();
        role = StaffRole.Manager;
        restaurantId = Guid.NewGuid();
        obj.FullName = fullName;
        obj.ShiftHours = shiftHours;
        obj.Role = role;
        obj.RestaurantId = restaurantId;
    }

    [TestMethod] public void FullNameTest() => areEqual(fullName, obj.FullName);
    [TestMethod] public void ShiftHoursTest() => areEqual(shiftHours, obj.ShiftHours);
    [TestMethod] public void RoleTest() => areEqual(role, obj.Role);
    [TestMethod] public void RestaurantIdTest() => areEqual(restaurantId, obj.RestaurantId);
}
