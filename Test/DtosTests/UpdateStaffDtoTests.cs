using Abc.Aids;
using Data.Restaurant.DTOs;
using Data.Restaurant.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class UpdateStaffDtoTests : BaseTests<UpdateStaffDto>
{
    private string fullName = string.Empty;
    private StaffRole role;
    private string shiftHours = string.Empty;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        fullName = GetRandom.String();
        role = StaffRole.Chef;
        shiftHours = GetRandom.String();
        obj.FullName = fullName;
        obj.Role = role;
        obj.ShiftHours = shiftHours;
    }

    [TestMethod] public void FullNameTest() => areEqual(fullName, obj.FullName);
    [TestMethod] public void RoleTest() => areEqual(role, obj.Role);
    [TestMethod] public void ShiftHoursTest() => areEqual(shiftHours, obj.ShiftHours);
}
