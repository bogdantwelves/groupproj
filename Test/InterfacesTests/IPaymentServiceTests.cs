using Domain.Restaurant.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Interfaces;

[TestClass]
public class IPaymentServiceTests : TestAids
{
    [TestInitialize] public void Initialize() => type = typeof(IPaymentService);

    [TestMethod] public void IsInterfaceTest() => areEqual(true, type.IsInterface);
    [TestMethod] public void NameTest() => areEqual("IPaymentService", type.Name);
    [TestMethod] public void NamespaceTest() => areEqual("Domain.Restaurant.Interfaces", type.Namespace);
    [TestMethod] public void MethodCountTest() => areEqual(1, type.GetMethods().Length);
    [TestMethod] public void PayAsyncTest() => areEqual(true, hasMethod("PayAsync"));

    private bool hasMethod(string name)
    {
        var methods = type.GetMethods();
        for (var i = 0; i < methods.Length; i++)
            if (methods[i].Name == name) return true;
        return false;
    }
}
