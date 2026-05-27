using System;
using Data.Restaurant.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Enums;

[TestClass]
public class OrderStatusTests : TestAids
{
    [TestInitialize] public void Initialize() => type = typeof(OrderStatus);

    [TestMethod] public void CountTest() => areEqual(5, Enum.GetNames(typeof(OrderStatus)).Length);
    [TestMethod] public void CreatedTest() => areEqual(1, (int)OrderStatus.Created);
    [TestMethod] public void PreparingTest() => areEqual(2, (int)OrderStatus.Preparing);
    [TestMethod] public void ServedTest() => areEqual(3, (int)OrderStatus.Served);
    [TestMethod] public void CancelledTest() => areEqual(4, (int)OrderStatus.Cancelled);
    [TestMethod] public void PaidTest() => areEqual(5, (int)OrderStatus.Paid);
}
