using System;
using Data.Restaurant.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Enums;

[TestClass]
public class PaymentMethodTests : TestAids
{
    [TestInitialize] public void Initialize() => type = typeof(PaymentMethod);

    [TestMethod] public void CountTest() => areEqual(3, Enum.GetNames(typeof(PaymentMethod)).Length);
    [TestMethod] public void CashTest() => areEqual(1, (int)PaymentMethod.Cash);
    [TestMethod] public void CardTest() => areEqual(2, (int)PaymentMethod.Card);
    [TestMethod] public void OnlineTest() => areEqual(3, (int)PaymentMethod.Online);
}
