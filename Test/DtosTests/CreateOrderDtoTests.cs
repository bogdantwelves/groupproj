using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Restaurant.DTOs;
using Abc.Aids;

namespace Data.Restaurant.Tests.DTOs;

[TestClass] 
public class CreateOrderDtoTests : BaseTests<CreateOrderDto>
{
    [TestInitialize] 
    public override void Initialize()
    {
        base.Initialize();
        obj.CustomerName = GetRandom.String();
        obj.ReservationId = Guid.NewGuid();
        obj.Items = new List<CreateOrderItemDto>();
    }

    [TestMethod] public void CustomerNameTest() => areEqual(obj.CustomerName, obj.CustomerName);
    [TestMethod] public void ReservationIdTest() => areEqual(obj.ReservationId, obj.ReservationId);
    [TestMethod] public void ItemsTest() => areEqual(obj.Items, obj.Items);
}