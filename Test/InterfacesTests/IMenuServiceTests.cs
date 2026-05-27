using Domain.Restaurant.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Interfaces;

[TestClass]
public class IMenuServiceTests : TestAids
{
    [TestInitialize] public void Initialize() => type = typeof(IMenuService);

    [TestMethod] public void IsInterfaceTest() => areEqual(true, type.IsInterface);
    [TestMethod] public void NameTest() => areEqual("IMenuService", type.Name);
    [TestMethod] public void NamespaceTest() => areEqual("Domain.Restaurant.Interfaces", type.Namespace);
    [TestMethod] public void MethodCountTest() => areEqual(4, type.GetMethods().Length);

    [TestMethod] public void GetMenuItemsAsyncTest() => areEqual(true, hasMethod("GetMenuItemsAsync"));
    [TestMethod] public void AddMenuItemAsyncTest() => areEqual(true, hasMethod("AddMenuItemAsync"));
    [TestMethod] public void UpdateMenuItemAsyncTest() => areEqual(true, hasMethod("UpdateMenuItemAsync"));
    [TestMethod] public void DeleteMenuItemAsyncTest() => areEqual(true, hasMethod("DeleteMenuItemAsync"));
}
