using Domain.Restaurant.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Interfaces;

[TestClass]
public class IBookingServiceTests : TestAids
{
    [TestInitialize] public void Initialize() => type = typeof(IBookingService);

    [TestMethod] public void IsInterfaceTest() => areEqual(true, type.IsInterface);
    [TestMethod] public void NameTest() => areEqual("IBookingService", type.Name);
    [TestMethod] public void NamespaceTest() => areEqual("Domain.Restaurant.Interfaces", type.Namespace);
    [TestMethod] public void MethodCountTest() => areEqual(6, type.GetMethods().Length);

    [TestMethod] public void CreateReservationAsyncTest() => areEqual(true, hasMethod("CreateReservationAsync"));
    [TestMethod] public void GetAllReservationsAsyncTest() => areEqual(true, hasMethod("GetAllReservationsAsync"));
    [TestMethod] public void GetReservationsByCustomerAsyncTest() => areEqual(true, hasMethod("GetReservationsByCustomerAsync"));
    [TestMethod] public void UpdateReservationAsyncTest() => areEqual(true, hasMethod("UpdateReservationAsync"));
    [TestMethod] public void CancelReservationAsyncTest() => areEqual(true, hasMethod("CancelReservationAsync"));
    [TestMethod] public void DeleteReservationAsyncTest() => areEqual(true, hasMethod("DeleteReservationAsync"));

    private bool hasMethod(string name)
    {
        var methods = type.GetMethods();
        for (var i = 0; i < methods.Length; i++)
            if (methods[i].Name == name) return true;
        return false;
    }
}
