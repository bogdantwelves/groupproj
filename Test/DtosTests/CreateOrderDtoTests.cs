using System;
using System.Collections.Generic;
using Abc.Aids;
using Data.Restaurant.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Restaurant.Tests.DTOs;

[TestClass]
public class CreateOrderDtoTests : BaseTests<CreateOrderDto>
{
    private string customerName = string.Empty;
    private Guid? reservationId;
    private List<CreateOrderItemDto> items = new();

    [TestInitialize]
    public override void Initialize()
    {
        base.Initialize();
        customerName = GetRandom.String();
        reservationId = Guid.NewGuid();
        items = new List<CreateOrderItemDto> { new() };
        obj.CustomerName = customerName;
        obj.ReservationId = reservationId;
        obj.Items = items;
    }

    [TestMethod] public void CustomerNameTest() => areEqual(customerName, obj.CustomerName);
    [TestMethod] public void ReservationIdTest() => areEqual(reservationId, obj.ReservationId);
    [TestMethod] public void ItemsTest() => areSame(items, obj.Items);
}
