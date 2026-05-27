using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Restaurant.DTOs;
using Abc.Aids;

namespace Data.Restaurant.Tests.DTOs;

[TestClass] 
public class StaffDtoTests : BaseTests<StaffDto>
{
    [TestInitialize] 
    public override void Initialize()
    {
        base.Initialize();
        obj.Id = Guid.NewGuid();
        obj.FullName = GetRandom.String();
        obj.ShiftHours = GetRandom.String();
        obj.Role = GetRandom.String();
        obj.RestaurantId = Guid.NewGuid();
    }

    [TestMethod] public void IdTest() => areEqual(obj.Id, obj.Id);
    [TestMethod] public void FullNameTest() => areEqual(obj.FullName, obj.FullName);
    [TestMethod] public void ShiftHoursTest() => areEqual(obj.ShiftHours, obj.ShiftHours);
    [TestMethod] public void RoleTest() => areEqual(obj.Role, obj.Role);
    [TestMethod] public void RestaurantIdTest() => areEqual(obj.RestaurantId, obj.RestaurantId);
}