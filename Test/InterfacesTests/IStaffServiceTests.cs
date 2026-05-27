using Domain.Restaurant.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Interfaces;

[TestClass]
public class IStaffServiceTests : TestAids
{
    [TestInitialize] public void Initialize() => type = typeof(IStaffService);

    [TestMethod] public void IsInterfaceTest() => areEqual(true, type.IsInterface);
    [TestMethod] public void NameTest() => areEqual("IStaffService", type.Name);
    [TestMethod] public void NamespaceTest() => areEqual("Domain.Restaurant.Interfaces", type.Namespace);
    [TestMethod] public void MethodCountTest() => areEqual(4, type.GetMethods().Length);

    [TestMethod] public void GetStaffAsyncTest() => areEqual(true, hasMethod("GetStaffAsync"));
    [TestMethod] public void CreateStaffAsyncTest() => areEqual(true, hasMethod("CreateStaffAsync"));
    [TestMethod] public void UpdateStaffAsyncTest() => areEqual(true, hasMethod("UpdateStaffAsync"));
    [TestMethod] public void DeleteStaffAsyncTest() => areEqual(true, hasMethod("DeleteStaffAsync"));
}
