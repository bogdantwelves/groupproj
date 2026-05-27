using System;
using System.Collections.Generic;
using Abc.Aids;
using Data.Restaurant.Entities;
using Data.Restaurant.Enums;
using Data.Restaurant.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Entities;

[TestClass]
public class OrderTests : BaseTests<Order>
{
    private Guid id;
    private DateTime createdAt;
    private OrderStatus status;
    private Guid customerId;
    private Customer? customer;
    private Guid? reservationId;
    private Reservation? reservation;
    private List<OrderItem> items = new();
    private Payment? payment;
    private decimal totalAmount;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        createdAt = GetRandom.DateTime();
        status = OrderStatus.Preparing;
        customerId = Guid.NewGuid();
        customer = new Customer();
        reservationId = Guid.NewGuid();
        reservation = new Reservation();
        payment = new Payment();
        var firstItem = new OrderItem { Quantity = GetRandom.Int32(), UnitPrice = GetRandom.Decimal() };
        var secondItem = new OrderItem { Quantity = GetRandom.Int32(), UnitPrice = GetRandom.Decimal() };
        items = new List<OrderItem> { firstItem, secondItem };
        totalAmount = firstItem.Quantity * firstItem.UnitPrice;
        totalAmount += secondItem.Quantity * secondItem.UnitPrice;
        obj.Id = id;
        obj.CreatedAt = createdAt;
        obj.Status = status;
        obj.CustomerId = customerId;
        obj.Customer = customer;
        obj.ReservationId = reservationId;
        obj.Reservation = reservation;
        obj.Items = items;
        obj.Payment = payment;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void CreatedAtTest() => areEqual(createdAt, obj.CreatedAt);
    [TestMethod] public void StatusTest() => areEqual(status, obj.Status);
    [TestMethod] public void CustomerIdTest() => areEqual(customerId, obj.CustomerId);
    [TestMethod] public void CustomerTest() => areSame(customer, obj.Customer);
    [TestMethod] public void ReservationIdTest() => areEqual(reservationId, obj.ReservationId);
    [TestMethod] public void ReservationTest() => areSame(reservation, obj.Reservation);
    [TestMethod] public void ItemsTest() => areSame(items, obj.Items);
    [TestMethod] public void PaymentTest() => areSame(payment, obj.Payment);
    [TestMethod] public void TotalAmountTest() => areEqual(totalAmount, obj.TotalAmount);
}
