using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Restaurant.DTOs;
using Data.Restaurant.Enums;
using Abc.Aids;

namespace Data.Restaurant.Tests.DTOs;

[TestClass] 
public class UpdateStaffDtoTests : BaseTests<UpdateStaffDto>
{
    [TestInitialize] 
    public override void Initialize()
    {
        base.Initialize();
        obj.FullName = GetRandom.String();
        obj.Role = (StaffRole)GetRandom.Int32();
        obj.ShiftHours = GetRandom.String();
    }

    [TestMethod] public void FullNameTest() => areEqual(obj.FullName, obj.FullName);
    [TestMethod] public void RoleTest() => areEqual(obj.Role, obj.Role);
    [TestMethod] public void ShiftHoursTest() => areEqual(obj.ShiftHours, obj.ShiftHours);
}