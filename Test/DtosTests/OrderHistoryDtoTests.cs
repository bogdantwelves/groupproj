using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Restaurant.DTOs;
using Abc.Aids;

namespace Data.Restaurant.Tests.DTOs;

[TestClass] 
public class OrderHistoryDtoTests : BaseTests<OrderHistoryDto>
{
    [TestInitialize] 
    public override void Initialize()
    {
        base.Initialize();
        obj.OrderId = Guid.NewGuid();
        obj.CustomerName = GetRandom.String();
        obj.TotalAmount = GetRandom.Decimal();
        obj.PaymentMethod = GetRandom.String();
        obj.PaymentState = GetRandom.String();
        obj.CreatedAt = GetRandom.DateTime();
    }

    [TestMethod] public void OrderIdTest() => areEqual(obj.OrderId, obj.OrderId);
    [TestMethod] public void CustomerNameTest() => areEqual(obj.CustomerName, obj.CustomerName);
    [TestMethod] public void TotalAmountTest() => areEqual(obj.TotalAmount, obj.TotalAmount);
    [TestMethod] public void PaymentMethodTest() => areEqual(obj.PaymentMethod, obj.PaymentMethod);
    [TestMethod] public void PaymentStateTest() => areEqual(obj.PaymentState, obj.PaymentState);
    [TestMethod] public void CreatedAtTest() => areEqual(obj.CreatedAt, obj.CreatedAt);
}