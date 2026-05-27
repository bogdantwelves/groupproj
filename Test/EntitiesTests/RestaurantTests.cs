using System;
using System.Collections.Generic;
using Abc.Aids;
using Data.Restaurant.Entities;
using Data.Restaurant.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantEntity = Data.Restaurant.Entities.Restaurant;

namespace Data.Restaurant.Tests.Entities;

[TestClass]
public class RestaurantTests : BaseTests<RestaurantEntity>
{
    private Guid id;
    private string name = string.Empty;
    private string address = string.Empty;
    private List<RestaurantTable> tables = new();
    private List<Menu> menus = new();
    private List<Reservation> reservations = new();
    private List<Staff> staff = new();
    private Inventory? inventory;

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        id = Guid.NewGuid();
        name = GetRandom.String();
        address = GetRandom.String();
        tables = new List<RestaurantTable> { new() };
        menus = new List<Menu> { new() };
        reservations = new List<Reservation> { new() };
        staff = new List<Staff> { new() };
        inventory = new Inventory();
        obj.Id = id;
        obj.Name = name;
        obj.Address = address;
        obj.Tables = tables;
        obj.Menus = menus;
        obj.Reservations = reservations;
        obj.Staff = staff;
        obj.Inventory = inventory;
    }

    [TestMethod] public void IdTest() => areEqual(id, obj.Id);
    [TestMethod] public void NameTest() => areEqual(name, obj.Name);
    [TestMethod] public void AddressTest() => areEqual(address, obj.Address);
    [TestMethod] public void TablesTest() => areSame(tables, obj.Tables);
    [TestMethod] public void MenusTest() => areSame(menus, obj.Menus);
    [TestMethod] public void ReservationsTest() => areSame(reservations, obj.Reservations);
    [TestMethod] public void StaffTest() => areSame(staff, obj.Staff);
    [TestMethod] public void InventoryTest() => areSame(inventory, obj.Inventory);
}
