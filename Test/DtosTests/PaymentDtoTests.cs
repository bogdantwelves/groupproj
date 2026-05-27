using System;
using Data.Restaurant.DTOs;
using Data.Restaurant.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class PaymentDtoTests : BaseTests<PaymentDto>
{
    private Guid orderId;
    private PaymentMethod method;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        orderId = Guid.NewGuid();
        method = PaymentMethod.Card;
        obj.OrderId = orderId;
        obj.Method = method;
    }

    [TestMethod] public void OrderIdTest() => areEqual(orderId, obj.OrderId);
    [TestMethod] public void MethodTest() => areEqual(method, obj.Method);
}
