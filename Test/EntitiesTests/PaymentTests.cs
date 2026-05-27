using System;
using Abc.Aids;
using Data.Restaurant.Entities;
using Data.Restaurant.Enums;
using Data.Restaurant.Tests.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Entities;

[TestClass]
public class PaymentTests : BaseTests<Payment>
{
    private Guid id;
    private Guid orderId;
    private Order? order;
    private decimal amount;
    private PaymentMethod method;
    private PaymentStatus status;
    private DateTime createdAt;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        orderId = Guid.NewGuid();
        order = new Order();
        amount = GetRandom.Decimal();
        method = PaymentMethod.Card;
        status = PaymentStatus.Paid;
        createdAt = GetRandom.DateTime();
        obj.Id = id;
        obj.OrderId = orderId;
        obj.Order = order;
        obj.Amount = amount;
        obj.Method = method;
        obj.Status = status;
        obj.CreatedAt = createdAt;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void OrderIdTest() => areEqual(orderId, obj.OrderId);
    [TestMethod] public void OrderTest() => areSame(order, obj.Order);
    [TestMethod] public void AmountTest() => areEqual(amount, obj.Amount);
    [TestMethod] public void MethodTest() => areEqual(method, obj.Method);
    [TestMethod] public void StatusTest() => areEqual(status, obj.Status);
    [TestMethod] public void CreatedAtTest() => areEqual(createdAt, obj.CreatedAt);
}
