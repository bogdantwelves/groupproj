using System;
using Abc.Aids;
using Data.Restaurant.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class OrderHistoryDtoTests : BaseTests<OrderHistoryDto>
{
    private Guid orderId;
    private string customerName = string.Empty;
    private decimal totalAmount;
    private string paymentMethod = string.Empty;
    private string paymentState = string.Empty;
    private DateTime createdAt;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        orderId = Guid.NewGuid();
        customerName = GetRandom.String();
        totalAmount = GetRandom.Decimal();
        paymentMethod = GetRandom.String();
        paymentState = GetRandom.String();
        createdAt = GetRandom.DateTime();
        obj.OrderId = orderId;
        obj.CustomerName = customerName;
        obj.TotalAmount = totalAmount;
        obj.PaymentMethod = paymentMethod;
        obj.PaymentState = paymentState;
        obj.CreatedAt = createdAt;
    }

    [TestMethod] public void OrderIdTest() => areEqual(orderId, obj.OrderId);
    [TestMethod] public void CustomerNameTest() => areEqual(customerName, obj.CustomerName);
    [TestMethod] public void TotalAmountTest() => areEqual(totalAmount, obj.TotalAmount);
    [TestMethod] public void PaymentMethodTest() => areEqual(paymentMethod, obj.PaymentMethod);
    [TestMethod] public void PaymentStateTest() => areEqual(paymentState, obj.PaymentState);
    [TestMethod] public void CreatedAtTest() => areEqual(createdAt, obj.CreatedAt);
}
