using System;
using System.Collections.Generic;
using Abc.Aids;
using Data.Restaurant.Entities;
using Data.Restaurant.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantEntity = Data.Restaurant.Entities.Restaurant;

namespace Data.Restaurant.Tests.Entities;

[TestClass]
public class RestaurantTableTests : BaseTests<RestaurantTable>
{
    private Guid id;
    private int tableNumber;
    private int capacity;
    private bool isAvailable;
    private Guid restaurantId;
    private RestaurantEntity? restaurant;
    private List<Reservation> reservations = new();

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        tableNumber = GetRandom.Int32();
        capacity = GetRandom.Int32();
        isAvailable = GetRandom.Int32() % 2 == 0;
        restaurantId = Guid.NewGuid();
        restaurant = new RestaurantEntity();
        reservations = new List<Reservation> { new() };
        obj.Id = id;
        obj.TableNumber = tableNumber;
        obj.Capacity = capacity;
        obj.IsAvailable = isAvailable;
        obj.RestaurantId = restaurantId;
        obj.Restaurant = restaurant;
        obj.Reservations = reservations;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void TableNumberTest() => areEqual(tableNumber, obj.TableNumber);
    [TestMethod] public void CapacityTest() => areEqual(capacity, obj.Capacity);
    [TestMethod] public void IsAvailableTest() => areEqual(isAvailable, obj.IsAvailable);
    [TestMethod] public void RestaurantIdTest() => areEqual(restaurantId, obj.RestaurantId);
    [TestMethod] public void RestaurantTest() => areSame(restaurant, obj.Restaurant);
    [TestMethod] public void ReservationsTest() => areSame(reservations, obj.Reservations);
}
