using Domain.Restaurant.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Interfaces;

[TestClass]
public class ITableServiceTests : TestAids
{
    [TestInitialize] public void Initialize() => type = typeof(ITableService);

    [TestMethod] public void IsInterfaceTest() => areEqual(true, type.IsInterface);
    [TestMethod] public void NameTest() => areEqual("ITableService", type.Name);
    [TestMethod] public void NamespaceTest() => areEqual("Domain.Restaurant.Interfaces", type.Namespace);
    [TestMethod] public void MethodCountTest() => areEqual(1, type.GetMethods().Length);
    [TestMethod] public void GetTablesAsyncTest() => areEqual(true, hasMethod("GetTablesAsync"));
}
