using Domain.Restaurant.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Interfaces;

[TestClass]
public class IOrderServiceTests : TestAids
{
    [TestInitialize] public void Initialize() => type = typeof(IOrderService);

    [TestMethod] public void IsInterfaceTest() => areEqual(true, type.IsInterface);
    [TestMethod] public void NameTest() => areEqual("IOrderService", type.Name);
    [TestMethod] public void NamespaceTest() => areEqual("Domain.Restaurant.Interfaces", type.Namespace);
    [TestMethod] public void MethodCountTest() => areEqual(4, type.GetMethods().Length);

    [TestMethod] public void CreateOrderAsyncTest() => areEqual(true, hasMethod("CreateOrderAsync"));
    [TestMethod] public void GetOrderTotalAsyncTest() => areEqual(true, hasMethod("GetOrderTotalAsync"));
    [TestMethod] public void GetOrderCountAsyncTest() => areEqual(true, hasMethod("GetOrderCountAsync"));
    [TestMethod] public void GetOrderHistoryAsyncTest() => areEqual(true, hasMethod("GetOrderHistoryAsync"));
}
