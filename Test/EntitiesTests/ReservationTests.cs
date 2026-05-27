using System;
using Abc.Aids;
using Data.Restaurant.Entities;
using Data.Restaurant.Enums;
using Data.Restaurant.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantEntity = Data.Restaurant.Entities.Restaurant;

namespace Data.Restaurant.Tests.Entities;

[TestClass]
public class ReservationTests : BaseTests<Reservation>
{
    private Guid id;
    private DateTime dateTime;
    private int partySize;
    private ReservationStatus status;
    private Guid customerId;
    private Customer? customer;
    private Guid restaurantId;
    private RestaurantEntity? restaurant;
    private Guid? restaurantTableId;
    private RestaurantTable? restaurantTable;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        dateTime = GetRandom.DateTime();
        partySize = GetRandom.Int32();
        status = ReservationStatus.Confirmed;
        customerId = Guid.NewGuid();
        customer = new Customer();
        restaurantId = Guid.NewGuid();
        restaurant = new RestaurantEntity();
        restaurantTableId = Guid.NewGuid();
        restaurantTable = new RestaurantTable();
        obj.Id = id;
        obj.DateTime = dateTime;
        obj.PartySize = partySize;
        obj.Status = status;
        obj.CustomerId = customerId;
        obj.Customer = customer;
        obj.RestaurantId = restaurantId;
        obj.Restaurant = restaurant;
        obj.RestaurantTableId = restaurantTableId;
        obj.RestaurantTable = restaurantTable;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void DateTimeTest() => areEqual(dateTime, obj.DateTime);
    [TestMethod] public void PartySizeTest() => areEqual(partySize, obj.PartySize);
    [TestMethod] public void StatusTest() => areEqual(status, obj.Status);
    [TestMethod] public void CustomerIdTest() => areEqual(customerId, obj.CustomerId);
    [TestMethod] public void CustomerTest() => areSame(customer, obj.Customer);
    [TestMethod] public void RestaurantIdTest() => areEqual(restaurantId, obj.RestaurantId);
    [TestMethod] public void RestaurantTest() => areSame(restaurant, obj.Restaurant);
    [TestMethod] public void RestaurantTableIdTest() => areEqual(restaurantTableId, obj.RestaurantTableId);
    [TestMethod] public void RestaurantTableTest() => areSame(restaurantTable, obj.RestaurantTable);
}
