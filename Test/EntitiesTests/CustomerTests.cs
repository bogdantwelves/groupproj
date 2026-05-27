using System;
using System.Collections.Generic;
using Abc.Aids;
using Data.Restaurant.Entities;
using Data.Restaurant.Tests.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.Entities;

[TestClass]
public class CustomerTests : BaseTests<Customer>
{
    private Guid id;
    private string fullName = string.Empty;
    private string email = string.Empty;
    private string phoneNumber = string.Empty;
    private List<Reservation> reservations = new();
    private List<Order> orders = new();

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        fullName = GetRandom.String();
        email = GetRandom.String();
        phoneNumber = GetRandom.String();
        reservations = new List<Reservation> { new() };
        orders = new List<Order> { new() };
        obj.Id = id;
        obj.FullName = fullName;
        obj.Email = email;
        obj.PhoneNumber = phoneNumber;
        obj.Reservations = reservations;
        obj.Orders = orders;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void FullNameTest() => areEqual(fullName, obj.FullName);
    [TestMethod] public void EmailTest() => areEqual(email, obj.Email);
    [TestMethod] public void PhoneNumberTest() => areEqual(phoneNumber, obj.PhoneNumber);
    [TestMethod] public void ReservationsTest() => areSame(reservations, obj.Reservations);
    [TestMethod] public void OrdersTest() => areSame(orders, obj.Orders);
}
