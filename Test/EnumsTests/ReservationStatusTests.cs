using System;
using Data.Restaurant.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Enums;

[TestClass]
public class ReservationStatusTests : TestAids
{
    [TestInitialize] public void Initialize() => type = typeof(ReservationStatus);

    [TestMethod] public void CountTest() => areEqual(4, Enum.GetNames(typeof(ReservationStatus)).Length);
    [TestMethod] public void PendingTest() => areEqual(1, (int)ReservationStatus.Pending);
    [TestMethod] public void ConfirmedTest() => areEqual(2, (int)ReservationStatus.Confirmed);
    [TestMethod] public void CancelledTest() => areEqual(3, (int)ReservationStatus.Cancelled);
    [TestMethod] public void CompletedTest() => areEqual(4, (int)ReservationStatus.Completed);
}
