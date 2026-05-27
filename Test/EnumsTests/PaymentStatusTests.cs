using System;
using Data.Restaurant.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Enums;

[TestClass]
public class PaymentStatusTests : TestAids
{
    [TestInitialize] public void Initialize() => type = typeof(PaymentStatus);

    [TestMethod] public void CountTest() => areEqual(4, Enum.GetNames(typeof(PaymentStatus)).Length);
    [TestMethod] public void PendingTest() => areEqual(1, (int)PaymentStatus.Pending);
    [TestMethod] public void PaidTest() => areEqual(2, (int)PaymentStatus.Paid);
    [TestMethod] public void FailedTest() => areEqual(3, (int)PaymentStatus.Failed);
    [TestMethod] public void RefundedTest() => areEqual(4, (int)PaymentStatus.Refunded);
}
