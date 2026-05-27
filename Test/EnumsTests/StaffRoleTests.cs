using System;
using Data.Restaurant.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Enums;

[TestClass]
public class StaffRoleTests : TestAids
{
    [TestInitialize] public void Initialize() => type = typeof(StaffRole);

    [TestMethod] public void CountTest() => areEqual(4, Enum.GetNames(typeof(StaffRole)).Length);
    [TestMethod] public void AdminTest() => areEqual(1, (int)StaffRole.Admin);
    [TestMethod] public void WaiterTest() => areEqual(2, (int)StaffRole.Waiter);
    [TestMethod] public void ChefTest() => areEqual(3, (int)StaffRole.Chef);
    [TestMethod] public void ManagerTest() => areEqual(4, (int)StaffRole.Manager);
}
